using Microsoft.Extensions.Options;
using RestAPI.Core.DataLayer;

namespace RestAPI.Tests
{
    public static class RepositoryMocker
    {
        public static IMoneyBoxRepository MoneyBoxRepository
        {
            get
            {
                var appSettings = Options.Create(new AppSettings
                {
                    ConnectionString = "Data Source=(localdb)\\v11.0;Initial Catalog=MoneyBoxDb;Integrated Security=True"
                });

                var entityMapper = new MoneyBoxEntityMapper() as IEntityMapper;

                return new MoneyBoxRepository(new MoneyBoxDbContext(appSettings, entityMapper)) as IMoneyBoxRepository;
            }
        }
    }
}
