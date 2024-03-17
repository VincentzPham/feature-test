using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_role",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_user_role",
                table: "AspNetUsers",
                column: "user_role");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_user_role",
                table: "AspNetUsers",
                column: "user_role",
                principalTable: "AspNetRoles",
                principalColumn: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_user_role",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_user_role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_role",
                table: "AspNetUsers");
        }
    }
}
