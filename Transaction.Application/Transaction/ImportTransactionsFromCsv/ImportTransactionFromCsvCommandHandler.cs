﻿using System.Globalization;
using Dapper;
using MediatR;
using TimeZoneConverter;
using Transaction.Application.Abstractions;
using Transaction.Application.Dtos;

namespace Transaction.Application.Transaction.ImportTransactionsFromCsv;

public class ImportTransactionFromCsvCommandHandler : IRequestHandler<ImportTransactionFromCsvCommand>
{
    private readonly ICsvService _csvService;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ITimeZoneService _timeZoneService;

    public ImportTransactionFromCsvCommandHandler(
        ICsvService csvService, 
        ISqlConnectionFactory sqlConnectionFactory,
        ITimeZoneService timeZoneService)
    {
        _csvService = csvService;
        _sqlConnectionFactory = sqlConnectionFactory;
        _timeZoneService = timeZoneService;
    }
    public async Task Handle(ImportTransactionFromCsvCommand request, CancellationToken cancellationToken)
    {
        var transactionsFromCsv = _csvService.ReadCsv<TransactionImport>(request.CsvFile);
        
        var transactions = transactionsFromCsv.Select(tc =>
            {
                var timeZoneInfo = _timeZoneService.GetTimeZoneInfo(tc.client_location);
                var dateTimeUtc = TimeZoneInfo.ConvertTimeToUtc(tc.transaction_date, timeZoneInfo);
                var timeZoneId = TZConvert.TryWindowsToIana(timeZoneInfo.Id, out var ianaTimeZone)
                    ? ianaTimeZone
                    : timeZoneInfo.Id;
                return new Models.Transaction.Transaction
                {
                    TransactionId = tc.transaction_id,
                    Name = tc.name,
                    Email = tc.email,
                    Amount = decimal.TryParse(tc.amount, NumberStyles.Currency, new NumberFormatInfo
                    {
                        CurrencyDecimalSeparator = ".",
                        CurrencySymbol = "$"
                    }, out var result)
                        ? result
                        : -1m,
                    UtcTransactionDate = dateTimeUtc,
                    ClientLocation = tc.client_location,
                    TimeZoneId = timeZoneId
                };
            }
        ).ToList();
        await using var connection =  _sqlConnectionFactory.CreateConnection();
        var query = $"""
                     insert into transactions ("transactionId" ,"name", "email", "amount", "utcTransactionDate", "clientLocation", "timeZoneId")
                        values(@TransactionId, @Name, @Email, @Amount, @UtcTransactionDate, @ClientLocation, @TimeZoneId)
                        ON CONFLICT ("transactionId") DO UPDATE 
                     SET name = excluded.name, email = excluded.email, amount = excluded.amount, "utcTransactionDate" = excluded."utcTransactionDate", "clientLocation" = excluded."clientLocation", "timeZoneId" = excluded."timeZoneId";
                     """;
        var rowsAffected = await connection.ExecuteAsync(query, transactions);
        
        if (rowsAffected != transactions.Count)
        {
            throw new Exception("Error occurred while importing transactions");
        }
    }
}