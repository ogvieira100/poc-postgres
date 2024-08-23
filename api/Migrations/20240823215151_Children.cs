using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Children : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChildrenId",
                table: "Certificados",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_ChildrenId",
                table: "Certificados",
                column: "ChildrenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Certificados_ChildrenId",
                table: "Certificados",
                column: "ChildrenId",
                principalTable: "Certificados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Certificados_ChildrenId",
                table: "Certificados");

            migrationBuilder.DropIndex(
                name: "IX_Certificados_ChildrenId",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Certificados");
        }
    }
}
