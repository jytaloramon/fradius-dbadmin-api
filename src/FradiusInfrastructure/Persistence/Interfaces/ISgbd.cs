using Microsoft.EntityFrameworkCore;

namespace FradiusInfrastructure.Persistence.Interfaces;

public interface ISgbd
{
    public Func<DbContextOptionsBuilder, Action?> GetOptionsBuilderConstructor();
}