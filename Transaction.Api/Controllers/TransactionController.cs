using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    
    [HttpPost]
    public async Task<IActionResult> ImportFromCsv([FromForm] IFormFile file)
    {
        
        
        return Ok();
    }
}