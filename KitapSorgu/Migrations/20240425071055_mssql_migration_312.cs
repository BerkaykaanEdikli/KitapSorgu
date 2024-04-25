using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitapSorgu.Migrations
{
    public partial class mssql_migration_312 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KitapYazari = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KitapTur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayinEvi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");
        }
    }
}
