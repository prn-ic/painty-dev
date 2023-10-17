using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateuser_roletablealtertouser_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_user_role_role_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_role",
                table: "user_role");

            migrationBuilder.RenameTable(
                name: "user_role",
                newName: "user_roles");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "user_roles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_user_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "user_roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_user_roles_role_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                table: "user_roles");

            migrationBuilder.RenameTable(
                name: "user_roles",
                newName: "user_role");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_role",
                table: "user_role",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_user_role_role_id",
                table: "users",
                column: "role_id",
                principalTable: "user_role",
                principalColumn: "id");
        }
    }
}
