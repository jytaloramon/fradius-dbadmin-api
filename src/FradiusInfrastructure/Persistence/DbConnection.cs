using FradiusDomain.Admin.Entities;
using Microsoft.EntityFrameworkCore;

namespace FradiusInfrastructure.Persistence;

public abstract class DbConnection : DbContext
{
    protected readonly string Host;
    protected readonly string User;
    protected readonly string Password;
    protected readonly string DbName;

    public DbSet<AdminUser> AdminUsers { get; set; }

    protected DbConnection(string host, string user, string password, string dbName)
    {
        Host = host;
        User = user;
        Password = password;
        DbName = dbName;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
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
    }
}