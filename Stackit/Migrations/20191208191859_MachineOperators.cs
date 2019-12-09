using Microsoft.EntityFrameworkCore.Migrations;

namespace Stackit.Migrations
{
    public partial class MachineOperators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Operators_OperatorID",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_OperatorID",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "OperatorID",
                table: "Machines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorID",
                table: "Machines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_OperatorID",
                table: "Machines",
                column: "OperatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Operators_OperatorID",
                table: "Machines",
                column: "OperatorID",
                principalTable: "Operators",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
