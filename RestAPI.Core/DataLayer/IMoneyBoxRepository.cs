using System;
using System.Linq;
using System.Threading.Tasks;
using RestAPI.Core.EntityLayer;

namespace RestAPI.Core.DataLayer
{
    public interface IMoneyBoxRepository : IDisposable
    {
        IQueryable<Transaction> GetAllTransactions();
        Task<Transaction> GetTransactionAsync(Transaction entity);
        Task<Transaction> AddTransactionAsync(Transaction entity);
        Task<Transaction> UpdateTransactionAsync(Transaction changes);
        Task<Transaction> DeleteTransactionAsync(Transaction changes);
    }
}
