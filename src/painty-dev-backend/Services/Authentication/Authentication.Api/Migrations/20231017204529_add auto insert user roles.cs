using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Api.Migrations
{
    /// <inheritdoc />
    public partial class addautoinsertuserroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("49321231-46e1-4739-9e0d-c54c7177bc9d"), "user" },
                    { new Guid("86731a6e-4c9d-43aa-a71b-adae9c6e0d46"), "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: new Guid("49321231-46e1-4739-9e0d-c54c7177bc9d"));

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: new Guid("86731a6e-4c9d-43aa-a71b-adae9c6e0d46"));
        }
    }
}
