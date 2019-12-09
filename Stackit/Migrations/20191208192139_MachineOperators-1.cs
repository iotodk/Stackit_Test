using Microsoft.EntityFrameworkCore.Migrations;

namespace Stackit.Migrations
{
    public partial class MachineOperators1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineOperator_Machines_MachineId",
                table: "MachineOperator");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineOperator_Operators_OperatorId",
                table: "MachineOperator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operators",
                table: "Operators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machines",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_MachineOperator_OperatorId",
                table: "MachineOperator");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "MachineOperator");

            migrationBuilder.AddColumn<int>(
                name: "MOperatorId",
                table: "Operators",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Machines",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MOperatorId",
                table: "MachineOperator",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operators",
                table: "Operators",
                column: "MOperatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machines",
                table: "Machines",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineOperator_MOperatorId",
                table: "MachineOperator",
                column: "MOperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineOperator_Operators_MOperatorId",
                table: "MachineOperator",
                column: "MOperatorId",
                principalTable: "Operators",
                principalColumn: "MOperatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineOperator_Machines_MachineId",
                table: "MachineOperator",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineOperator_Operators_MOperatorId",
                table: "MachineOperator");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineOperator_Machines_MachineId",
                table: "MachineOperator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operators",
                table: "Operators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Machines",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_MachineOperator_MOperatorId",
                table: "MachineOperator");

            migrationBuilder.DropColumn(
                name: "MOperatorId",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "MOperatorId",
                table: "MachineOperator");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Operators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "MachineOperator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operators",
                table: "Operators",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Machines",
                table: "Machines",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_MachineOperator_OperatorId",
                table: "MachineOperator",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineOperator_Machines_MachineId",
                table: "MachineOperator",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineOperator_Operators_OperatorId",
                table: "MachineOperator",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
