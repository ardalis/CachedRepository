using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CachedRepoSample.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_UserList_UserId",
                table: "Resource");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Resource",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_UserId",
                table: "Resource",
                newName: "IX_Resource_AuthorId");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Authors_AuthorId",
                table: "Resource",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Authors_AuthorId",
                table: "Resource");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Resource",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_AuthorId",
                table: "Resource",
                newName: "IX_Resource_UserId");

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_UserList_UserId",
                table: "Resource",
                column: "UserId",
                principalTable: "UserList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
