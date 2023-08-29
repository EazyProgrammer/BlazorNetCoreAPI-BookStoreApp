using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d08bb0e-e4b8-4dff-8823-91a1a6a7140c", "f1683401-cd00-4096-a3ad-9f1d2561948b", "User", "USER" },
                    { "6ddd2d89-446b-415c-9f4d-bc66f05fb050", "fc9cd86c-0750-4f04-996c-1e210df3ed07", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "44e14083-ebde-4a91-b7e3-c874ba73239c", 0, "4ecc2cf4-1bb2-4780-8987-0e3b9557c3d2", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEGp7ocJpInLHbpUd7tNAMhA7PJud6418YzFeRWy/1bUG98Up0Cwg8jWZgnGHB5PVAg==", null, false, "c6605aec-ede4-4a1b-97dc-2631f07bef0e", false, "admin@bookstore.com" },
                    { "838144ee-b2f8-4101-87d5-3e081317c0fe", 0, "cf0eea8b-1b7b-4fd5-8617-6eb5cc93d308", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEP6PK7dGCbNqMOzmWLzJkFNX/dsRMns1UfKnRZZtzDwFGb16Zb/no8RpgwoeoEwPKw==", null, false, "468c38b5-7885-4f24-acd5-585dff6b0ae5", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ddd2d89-446b-415c-9f4d-bc66f05fb050", "44e14083-ebde-4a91-b7e3-c874ba73239c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5d08bb0e-e4b8-4dff-8823-91a1a6a7140c", "838144ee-b2f8-4101-87d5-3e081317c0fe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ddd2d89-446b-415c-9f4d-bc66f05fb050", "44e14083-ebde-4a91-b7e3-c874ba73239c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d08bb0e-e4b8-4dff-8823-91a1a6a7140c", "838144ee-b2f8-4101-87d5-3e081317c0fe" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d08bb0e-e4b8-4dff-8823-91a1a6a7140c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ddd2d89-446b-415c-9f4d-bc66f05fb050");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44e14083-ebde-4a91-b7e3-c874ba73239c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "838144ee-b2f8-4101-87d5-3e081317c0fe");
        }
    }
}
