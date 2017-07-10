using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace RestAPI.Core.DataLayer
{
    public class MoneyBoxDbContext : DbContext
    {
        private string ConnectionString { get; }
        private IEntityMapper EntityMapper { get; }

        public MoneyBoxDbContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;
            EntityMapper = entityMapper;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
