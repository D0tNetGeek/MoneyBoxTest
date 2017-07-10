using Microsoft.EntityFrameworkCore;

namespace RestAPI.Core.DataLayer
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
