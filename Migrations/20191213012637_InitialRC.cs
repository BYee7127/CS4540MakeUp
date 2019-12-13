using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QinMilitary.Migrations
{
    public partial class InitialRC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    OfficerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Years = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.OfficerID);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    UnitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Numbers = table.Column<int>(nullable: false),
                    OfficerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitID);
                    table.ForeignKey(
                        name: "FK_Unit_Officer_OfficerID",
                        column: x => x.OfficerID,
                        principalTable: "Officer",
                        principalColumn: "OfficerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soldier",
                columns: table => new
                {
                    SoldierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Birthplace = table.Column<string>(nullable: true),
                    UnitID = table.Column<int>(nullable: false),
                    COOfficerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldier", x => x.SoldierID);
                    table.ForeignKey(
                        name: "FK_Soldier_Officer_COOfficerID",
                        column: x => x.COOfficerID,
                        principalTable: "Officer",
                        principalColumn: "OfficerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldier_Unit_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Unit",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SolderID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Battle = table.Column<string>(nullable: true),
                    Reward = table.Column<string>(nullable: true),
                    SoldierID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.AchievementID);
                    table.ForeignKey(
                        name: "FK_Achievement_Soldier_SoldierID",
                        column: x => x.SoldierID,
                        principalTable: "Soldier",
                        principalColumn: "SoldierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfficerID = table.Column<int>(nullable: false),
                    SoldierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assignment_Officer_OfficerID",
                        column: x => x.OfficerID,
                        principalTable: "Officer",
                        principalColumn: "OfficerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Soldier_SoldierID",
                        column: x => x.SoldierID,
                        principalTable: "Soldier",
                        principalColumn: "SoldierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_SoldierID",
                table: "Achievement",
                column: "SoldierID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_OfficerID",
                table: "Assignment",
                column: "OfficerID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_SoldierID",
                table: "Assignment",
                column: "SoldierID");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_COOfficerID",
                table: "Soldier",
                column: "COOfficerID");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_UnitID",
                table: "Soldier",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_OfficerID",
                table: "Unit",
                column: "OfficerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Soldier");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Officer");
        }
    }
}
