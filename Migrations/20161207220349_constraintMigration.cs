using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace methub.Migrations
{
    public partial class constraintMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    comment = table.Column<string>(nullable: true),
                    constraint_type = table.Column<int>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: true),
                    frequency = table.Column<int>(nullable: false),
                    max_time = table.Column<DateTime>(nullable: true),
                    min_time = table.Column<DateTime>(nullable: true),
                    priority = table.Column<int>(nullable: false),
                    rol = table.Column<int>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ConstraintDetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Constraintid = table.Column<int>(nullable: true),
                    constraint_id = table.Column<int>(nullable: false),
                    day_id = table.Column<int>(nullable: false),
                    is_valid_day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstraintDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConstraintDetail_Constraints_Constraintid",
                        column: x => x.Constraintid,
                        principalTable: "Constraints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintDetail_Constraintid",
                table: "ConstraintDetail",
                column: "Constraintid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstraintDetail");

            migrationBuilder.DropTable(
                name: "Constraints");
        }
    }
}
