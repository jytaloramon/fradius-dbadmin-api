using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FradiusMigration.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("tb_admin_user", columns: table => new
            {
                Id = table.Column<int>(name: "admu_id", type:"SERIAL"),
                FirstName = table.Column<String>(name: "admu_first_name", type:"VARCHAR (64)"),
                LastName = table.Column<String>(name: "admu_last_name", type:"VARCHAR (64)"),
                Username = table.Column<String>(name: "admu_username", type:"VARCHAR (32)"),
                Email = table.Column<String>(name: "admu_email", type:"VARCHAR (64)"),
                Password = table.Column<String>(name: "admu_password", type:"VARCHAR (72)"),
                ProfileImage = table.Column<String>(name: "admu_profile_image", type:"VARCHAR (64)", nullable:true),
                CreateAt = table.Column<DateTime>(name: "admu_create_at", type:"TIMESTAMP", defaultValueSql:"CURRENT_TIMESTAMP"),
                UpdateAt = table.Column<DateTime>(name: "admu_update_at", type:"TIMESTAMP", defaultValueSql:"CURRENT_TIMESTAMP"),
                IsActive = table.Column<bool>(name: "admu_is_active", type:"BOOLEAN", defaultValueSql:"true")
            }, constraints: table =>
            {
                table.PrimaryKey("PK_admu_id", c => c.Id);
                table.UniqueConstraint("UQ_admu_username", c => c.Username);
                table.UniqueConstraint("UQ_admu_email", c => c.Email);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("tb_admin_user");
        }
    }
}
