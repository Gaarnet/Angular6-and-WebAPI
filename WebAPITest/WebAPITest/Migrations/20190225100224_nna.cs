using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPITest.Migrations
{
    public partial class nna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
