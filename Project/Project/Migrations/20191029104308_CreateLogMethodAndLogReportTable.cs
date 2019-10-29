using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class CreateLogMethodAndLogReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "logReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    LogMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_logReports_logMethods_LogMethodId",
                        column: x => x.LogMethodId,
                        principalTable: "logMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_logReports_LogMethodId",
                table: "logReports",
                column: "LogMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logReports");

            migrationBuilder.DropTable(
                name: "logMethods");
        }
    }
}
