using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestAPI.Core.EntityLayer;

namespace RestAPI.Core.DataLayer
{
    public class MoneyBoxRepository : IMoneyBoxRepository
    {
        private readonly MoneyBoxDbContext _dbContext;
        private Boolean _disposed;

        public MoneyBoxRepository(MoneyBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _disposed = true;
                }
            }
        }

        public IQueryable<Transaction> GetAllTransactions()
        {
            var transactions =  _dbContext.Set<Transaction>();

            return transactions;
        }

        public Task<Transaction> GetTransactionAsync(Transaction entity)
        {
            var result = _dbContext.Set<Transaction>().FirstOrDefaultAsync(item => item.TransactionId == entity.TransactionId);
            return result;
        }

        public async Task<Transaction> AddTransactionAsync(Transaction entity)
        {
            entity.TransactionDate = entity.TransactionDate;
            entity.Description = entity.Description;
            entity.TransactionAmount = entity.TransactionAmount;
            entity.CreatedDate = entity.CreatedDate;
            entity.ModifiedDate = entity.ModifiedDate;
            entity.CurrencyCode = entity.CurrencyCode;
            entity.Merchant = entity.Merchant;

            _dbContext.Set<Transaction>().Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Transaction> UpdateTransactionAsync(Transaction changes)
        {
            var entity = await GetTransactionAsync(changes);

            if (entity != null)
            {
                entity.TransactionDate = changes.TransactionDate;
                entity.Description = changes.Description;
                entity.TransactionAmount = changes.TransactionAmount;
                entity.CreatedDate = changes.CreatedDate;
                entity.ModifiedDate = changes.ModifiedDate;
                entity.CurrencyCode = changes.CurrencyCode;
                entity.Merchant = changes.Merchant;

                await _dbContext.SaveChangesAsync();
            }

            return changes;
        }

        public async Task<Transaction> DeleteTransactionAsync(Transaction changes)
        {
            var entity = await GetTransactionAsync(changes);

            if (entity != null)
            {
                _dbContext.Set<Transaction>().Remove(entity);

                await _dbContext.SaveChangesAsync();
            }

            return entity;
        }
    }
}
