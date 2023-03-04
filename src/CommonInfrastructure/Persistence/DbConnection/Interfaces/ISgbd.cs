using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Db.Interfaces;

public interface ISgbd
{
    public Func<DbContextOptionsBuilder, Action?> GetOptionsBuilderConstructor();
}