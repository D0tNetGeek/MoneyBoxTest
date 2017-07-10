using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Core.DataLayer;
using RestAPI.Core.EntityLayer;
using RestAPI.ViewModels;
using RestAPI.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Controllers
{
    /// <summary>
    /// API to implement all the end points.
    /// </summary>
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly IMoneyBoxRepository _repository;

        /// <summary>
        /// Constructor with repository injection.
        /// </summary>
        /// <param name="repository"></param>
        public TransactionController(IMoneyBoxRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Garbage collection.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(Boolean disposing)
        {
            _repository?.Dispose();

            base.Dispose(disposing);
        }

        //POST transaction/CreateTransaction
        /// <summary>
        /// The API must have an endpoint to create a new transaction.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>Creates a transaction.</returns>
        [HttpPost("CreateTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody]TransactionViewModel transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            var entity = await _repository.AddTransactionAsync(transaction.ToEntity());

            return CreatedAtRoute("GetAllTransaction", new { id = transaction.TransactionId }, entity);
        }

        //PUT 
        /// <summary>
        /// The API must have an endpoint to update a transaction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPut("UpdateTransaction/{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody]TransactionViewModel transaction)
        {
            if (transaction == null || transaction.TransactionId != id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateTransactionAsync(transaction.ToEntity());

            return Ok(result);
        }

        /// <summary>
        /// The API must have an endpoint to delete a transaction.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            if (id == 0 )
            {
                return BadRequest();
            }

            await _repository.DeleteTransactionAsync(new Transaction { TransactionId = id });

            return Ok();
        }

        // GET transaction/GetTransaction/2
        /// <summary>
        /// The API must have an endpoint to get a transaction.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetTransaction/{id}", Name = "GetTransaction")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var entity = await _repository.GetTransactionAsync(new Transaction { TransactionId = id });

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity.ToViewModel());
        }

        //GET transaction/getAllTransactions
        /// <summary>
        /// The API must have an endpoint to get a list of all transactions.
        /// </summary>
        /// <returns>List response</returns>
        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var result = new List<TransactionViewModel>();

            try
            {
                result = await _repository.GetAllTransactions()
                    .Select(item => item.ToViewModel())
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                NotFound(ex.Message);
            }

            return Ok(result);
        }
    }
}
