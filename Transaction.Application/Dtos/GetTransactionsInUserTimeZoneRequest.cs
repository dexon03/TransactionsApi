using System.ComponentModel.DataAnnotations;

namespace Transaction.Application.Dtos;

public record GetTransactionsInUserTimeZoneRequest
{
    public int? Year { get; init; }
    [Range(1,12)]
    public int? Month { get; init; }

    public DateTimeOffset UserOffset { get; init; }
};