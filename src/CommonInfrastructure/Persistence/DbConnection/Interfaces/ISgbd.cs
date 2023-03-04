using Microsoft.EntityFrameworkCore;

namespace CommonInfrastructure.Persistence.DbConnection.Interfaces;

public interface ISgbd
{
    public Func<DbContextOptionsBuilder, Action?> GetOptionsBuilderConstructor();
}