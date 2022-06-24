using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlinePizzaThirstSatisfied.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stockAvailable",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stockAvailable",
                table: "Pizzas");
        }
    }
}
