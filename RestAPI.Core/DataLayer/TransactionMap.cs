using Microsoft.EntityFrameworkCore;
using RestAPI.Core.EntityLayer;

namespace RestAPI.Core.DataLayer
{
    public class TransactionMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Transaction>();

            entity.ToTable("Transaction");
            entity.HasKey(t => new { t.TransactionId });
            entity.Property(t => t.TransactionId).UseSqlServerIdentityColumn();
        }
    }
}
