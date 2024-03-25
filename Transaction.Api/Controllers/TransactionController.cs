using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Dtos;
using Transaction.Application.Transaction.ExportTransactionsToExcel;
using Transaction.Application.Transaction.GetTransactionByDateInUserTimeZone;
using Transaction.Application.Transaction.GetTransactionDateApiTimeZone;
using Transaction.Application.Transaction.GetTransactionsInInterval;
using Transaction.Application.Transaction.ImportTransactionsFromCsv;

namespace Transaction.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController: ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("user-timezone")]
    public async Task<IActionResult> GetTransactionsByYearInUserTimeZone([FromQuery]GetTransactionInInterval request)
    {
        var transactions = await _mediator.Send(new GetTransactionByDateInUserTimeZoneQuery(request.DateFrom, request.DateTo));
        
        return Ok(transactions);
    }
    
    [HttpGet("api-timezone")]
    public async Task<IActionResult> GetTransactionsByYearInApiTimeZone([FromQuery]GetTransactionInInterval request)
    {
        var transactions = await _mediator.Send(new GetTransactionByDateInApiTimeZoneQuery(request.DateFrom, request.DateTo));
        
        return Ok(transactions);
    }
    
    [HttpGet("interval")]
    public async Task<IActionResult> GetTransactionsInInterval([FromQuery]GetTransactionInInterval request)
    {
        var transactions = await _mediator.Send(new GetTransactionsInIntervalQuery(request.DateFrom, request.DateTo));
        
        return Ok(transactions);
    }
    
    [HttpPost]
    public async Task<IActionResult> ImportFromCsv(IFormFile file)
    {
        await _mediator.Send(new ImportTransactionFromCsvCommand(file.OpenReadStream()));
        
        return Ok();
    }
    
    [HttpGet("export")]
    public async Task<IActionResult> ExportToExcel()
    {
        var file = await _mediator.Send(new ExportTransactionToExcelCommand());
        
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "transactions.xlsx");
    }
}