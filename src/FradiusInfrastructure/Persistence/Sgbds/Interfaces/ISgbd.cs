using Microsoft.EntityFrameworkCore;

namespace FradiusInfrastructure.Persistence.Sgbds.Interfaces;

public interface ISgbd
{
    public Func<DbContextOptionsBuilder, Action?> GetOptionsBuilderConstructor();
}