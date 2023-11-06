using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Portal.Migrations
{
    /// <inheritdoc />
    public partial class courses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorId = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moduleAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
