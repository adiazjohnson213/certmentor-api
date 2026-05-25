using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertMentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToSkillArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SkillAreas",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SkillAreas");
        }
    }
}
