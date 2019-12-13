using Microsoft.EntityFrameworkCore.Migrations;

namespace QinMilitary.Migrations.QM
{
    public partial class AddCOID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldier_Officer_COOfficerID",
                table: "Soldier");

            migrationBuilder.RenameColumn(
                name: "COOfficerID",
                table: "Soldier",
                newName: "COID");

            migrationBuilder.RenameIndex(
                name: "IX_Soldier_COOfficerID",
                table: "Soldier",
                newName: "IX_Soldier_COID");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldier_Officer_COID",
                table: "Soldier",
                column: "COID",
                principalTable: "Officer",
                principalColumn: "OfficerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldier_Officer_COID",
                table: "Soldier");

            migrationBuilder.RenameColumn(
                name: "COID",
                table: "Soldier",
                newName: "COOfficerID");

            migrationBuilder.RenameIndex(
                name: "IX_Soldier_COID",
                table: "Soldier",
                newName: "IX_Soldier_COOfficerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldier_Officer_COOfficerID",
                table: "Soldier",
                column: "COOfficerID",
                principalTable: "Officer",
                principalColumn: "OfficerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
