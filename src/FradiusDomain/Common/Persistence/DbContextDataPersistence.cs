using CommonDomain.Persistence.Interfaces;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Common.Persistence.Repository;
using FradiusInfrastructure.Persistence.Sgbds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FradiusDomain.Common.Persistence;

public class DbContextDataPersistence : IDataPersistence<FradiusDbContextPersistence>
{
    private readonly ISgbd _sgbd;

    public DbContextDataPersistence(ISgbd sgbd)
    {
        _sgbd = sgbd;
    }

    public FradiusDbContextPersistence GetRepositoryData()
    {
        return new FradiusDbContextPersistence(_sgbd.GetOptionsBuilderConstructor(),
            modelBuilder =>
            {
                modelBuilder.Entity<AdminUser>(builder =>
                {
                    builder.ToTable("tb_admin_user");
                    builder.Property(a => a.Id).HasColumnName("admu_id").ValueGeneratedOnAdd();
                    builder.Property(a => a.FirstName).HasColumnName("admu_first_name");
                    builder.Property(a => a.LastName).HasColumnName("admu_last_name");
                    builder.Property(a => a.Username).HasColumnName("admu_username");
                    builder.Property(a => a.Email).HasColumnName("admu_email");
                    builder.Property(a => a.Password).HasColumnName("admu_password");
                    builder.Property(a => a.ProfileImage).HasColumnName("admu_profile_image");
                    builder.Property(a => a.CreateAt).HasColumnName("admu_create_at").ValueGeneratedOnAdd();
                    builder.Property(a => a.UpdateAt).HasColumnName("admu_update_at").ValueGeneratedOnAddOrUpdate();
                    builder.Property(a => a.IsActive).HasColumnName("admu_is_active");
                });

                return null;
            });
    }
}