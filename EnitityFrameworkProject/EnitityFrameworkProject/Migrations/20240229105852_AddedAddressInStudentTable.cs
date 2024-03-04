using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnitityFrameworkProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddressInStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CollegeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CollegeStudents");
        }
    }
}
