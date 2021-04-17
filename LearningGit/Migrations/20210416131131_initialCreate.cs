using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningGit.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleOrder = table.Column<int>(nullable: true),
                    TitleText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleID);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    StepID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StepOrder = table.Column<int>(nullable: true),
                    StepText = table.Column<string>(nullable: true),
                    StepCode = table.Column<string>(nullable: true),
                    TitleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.StepID);
                    table.ForeignKey(
                        name: "FK_Steps_Titles_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Titles",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TitleID",
                table: "Steps",
                column: "TitleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
