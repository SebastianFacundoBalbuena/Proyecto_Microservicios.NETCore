using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Persistence.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar CustomerId como columna con IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "Customer",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1"); // Agregar IDENTITY

            // Establecer CustomerId como la nueva clave primaria
            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "Customer",
                table: "Customers",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "Customer",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Customer",
                table: "Customers");
        }
    }
}
