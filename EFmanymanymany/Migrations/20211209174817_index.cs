using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFmanymanymany.Migrations
{
    public partial class index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PlayerId",
                table: "Positions",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_PlayerId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Positions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                columns: new[] { "PlayerId", "GameId" });
        }
    }
}
