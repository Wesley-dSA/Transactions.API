using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Transactions.API.Services.Models;

namespace Transactions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Services.Models.Transaction>> SearchAllTransactions()
        {
            return Ok();
        } 
    }
}
