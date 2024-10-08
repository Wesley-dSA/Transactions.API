using Microsoft.AspNetCore.Mvc;
using Transactions.API.Application.Extensions;
using Transactions.API.Application.ViewModels;
using Transactions.API.Services;

namespace Transactions.API.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionsController (ITransactionService transactionService): ControllerBase
{
    private readonly ITransactionService _transactionService = transactionService;

    [HttpGet("id/{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(TransactionViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int Id)
    {
        var trans = await _transactionService.GetByIdAsync(Id);

        if (trans is null)
            return NotFound();

        return Ok(trans.ToViewModel());
    }

    [HttpGet("Idsender/{Idsender}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(TransactionViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByInsender(string Idsender)
    {
        var trans = await _transactionService.GetByIdsenderAsync(Idsender);

        if (trans is null)
            return NotFound();

        return Ok(trans.ToViewModel());
    }

    [HttpGet("IdRecipient/{IdRecipient}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(TransactionViewModel), StatusCodes.Status200OK)]

    public async Task<IActionResult> GetByIdRecipient(string IdRecipient)
    {
        var trans = await _transactionService.GetByIdRecipientAsync(IdRecipient);

        if( trans is null)
            return NotFound();

        return Ok(trans.ToViewModel());
    }
}

