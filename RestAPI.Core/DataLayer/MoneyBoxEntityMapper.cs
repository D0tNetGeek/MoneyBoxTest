using System.Collections.Generic;

namespace RestAPI.Core.DataLayer
{
    public class MoneyBoxEntityMapper : EntityMapper
    {
        public MoneyBoxEntityMapper()
        {
            Mappings = new List<IEntityMap>
            {
                new TransactionMap()
            };
        }
    }
}
