using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Childrendelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Certificados_ChildrenId",
                table: "Certificados");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Certificados_ChildrenId",
                table: "Certificados",
                column: "ChildrenId",
                principalTable: "Certificados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Certificados_ChildrenId",
                table: "Certificados");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Certificados_ChildrenId",
                table: "Certificados",
                column: "ChildrenId",
                principalTable: "Certificados",
                principalColumn: "Id");
        }
    }
}
