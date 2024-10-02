using Microsoft.AspNetCore.Mvc;
using Users.API.Application.ViewModels;

namespace Transactions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _TransactionService = transactionService;

        [HttpGet("id/{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TransactionViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var trans = await _TransactionService.GetByIdAsync(id);

            if (trans is null)
                return NotFound();

            return Ok(trans.ToViewModel());
        }

        [HttpGet("document/{document:minlength(11):maxlength(14)}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TransactionViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByDocument(string document)
        {
            var trans = await _TransactionService.GetByDocumentAsync(document);

            if (trans is null)
                return NotFound();

            return Ok(trans.ToViewModel());
        }
    }
}
