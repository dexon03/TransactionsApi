using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Transaction.GetTransactionByYearApiTimeZone;
using Transaction.Application.Transaction.GetTransactionByYearInUserTimeZone;
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
    
    [HttpGet]
    public async Task<IActionResult> GetTransactionsByYearInUserTimeZone(int year,DateTimeOffset userTimeZoneOffset)
    {
        var transactions = await _mediator.Send(new GetTransactionByYearInUserTimeZoneQuery(year, userTimeZoneOffset));
        
        return Ok(transactions);
    }
    
    [HttpGet("{year}")]
    public async Task<IActionResult> GetTransactionsByYearInApiTimeZone(int year)
    {
        var transactions = await _mediator.Send(new GetTransactionByYearInApiTimeZoneQuery(year));
        
        return Ok(transactions);
    }
    
    [HttpPost]
    public async Task<IActionResult> ImportFromCsv(IFormFile file)
    {
        await _mediator.Send(new ImportTransactionFromCsvCommand(file.OpenReadStream()));
        
        return Ok();
    }
}