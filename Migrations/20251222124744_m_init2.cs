using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class m_init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type_operation",
                table: "DataInputVarians",
                newName: "Operation");

            migrationBuilder.RenameColumn(
                name: "Operand_2",
                table: "DataInputVarians",
                newName: "Num2");

            migrationBuilder.RenameColumn(
                name: "Operand_1",
                table: "DataInputVarians",
                newName: "Num1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operation",
                table: "DataInputVarians",
                newName: "Type_operation");

            migrationBuilder.RenameColumn(
                name: "Num2",
                table: "DataInputVarians",
                newName: "Operand_2");

            migrationBuilder.RenameColumn(
                name: "Num1",
                table: "DataInputVarians",
                newName: "Operand_1");
        }
    }
}
