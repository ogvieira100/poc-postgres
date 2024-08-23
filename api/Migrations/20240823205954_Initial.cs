using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoArquivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DocumentoContratante = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    NomeContratante = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NumeroContrato = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    DataInicial = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataFinal = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DocumentoContratada = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    NomeContratada = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AssinanteContratada = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CargoAssinanteContratada = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TelefoneAssinanteContratada = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EmailAssinanteContratada = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Apresentacao = table.Column<string>(type: "text", nullable: true),
                    EnderecoContratante = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ExtensaoArquivo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Glossario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Palavra = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    SynonymOfId = table.Column<int>(type: "integer", nullable: true),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glossario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Glossario_Glossario_SynonymOfId",
                        column: x => x.SynonymOfId,
                        principalTable: "Glossario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorasServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Qtd = table.Column<double>(type: "double precision", nullable: false),
                    CertificateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorasServico_Certificados_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosFuncao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Horas = table.Column<double>(type: "double precision", nullable: false),
                    CertificateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosFuncao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosFuncao_Certificados_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificadoGlossario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CertificateId = table.Column<Guid>(type: "uuid", nullable: false),
                    GlossaryEntryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadoGlossario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificadoGlossario_Certificados_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificadoGlossario_Glossario_GlossaryEntryId",
                        column: x => x.GlossaryEntryId,
                        principalTable: "Glossario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificadoGlossario_CertificateId",
                table: "CertificadoGlossario",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadoGlossario_GlossaryEntryId",
                table: "CertificadoGlossario",
                column: "GlossaryEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Glossario_SynonymOfId",
                table: "Glossario",
                column: "SynonymOfId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasServico_CertificateId",
                table: "HorasServico",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosFuncao_CertificateId",
                table: "PontosFuncao",
                column: "CertificateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificadoGlossario");

            migrationBuilder.DropTable(
                name: "HorasServico");

            migrationBuilder.DropTable(
                name: "PontosFuncao");

            migrationBuilder.DropTable(
                name: "Glossario");

            migrationBuilder.DropTable(
                name: "Certificados");
        }
    }
}
