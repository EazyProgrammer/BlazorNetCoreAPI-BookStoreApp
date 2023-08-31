using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class AddedColumnToAuthorTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Authors",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d08bb0e-e4b8-4dff-8823-91a1a6a7140c",
                column: "ConcurrencyStamp",
                value: "c74c0a15-2d45-41e7-9da6-53a44325c637");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ddd2d89-446b-415c-9f4d-bc66f05fb050",
                column: "ConcurrencyStamp",
                value: "526b71e1-8e64-4e3a-92e8-f97f41892e80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44e14083-ebde-4a91-b7e3-c874ba73239c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "610b65ab-ab78-4a08-8455-17540c8d8a8a", "AQAAAAEAACcQAAAAECoM6z+Lisu8RdtsCKhv+o0+2kfwkVMSn8xsc5opO1GxViuabT08aqV8Lu0lUCKdqg==", "fd069edf-985e-40cf-8688-98b263190aa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "838144ee-b2f8-4101-87d5-3e081317c0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dac2e7d9-5768-4df3-9458-d39186fdd825", "AQAAAAEAACcQAAAAEPa3graxh5vzyYfcJazlsgFXduyZ1eSGfMFl9/k6CfFGC8KgAYeyutq4riTBvb1cnw==", "28a59e12-fbf0-41e6-b191-7aa82b73b3f7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d08bb0e-e4b8-4dff-8823-91a1a6a7140c",
                column: "ConcurrencyStamp",
                value: "f1683401-cd00-4096-a3ad-9f1d2561948b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ddd2d89-446b-415c-9f4d-bc66f05fb050",
                column: "ConcurrencyStamp",
                value: "fc9cd86c-0750-4f04-996c-1e210df3ed07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44e14083-ebde-4a91-b7e3-c874ba73239c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ecc2cf4-1bb2-4780-8987-0e3b9557c3d2", "AQAAAAEAACcQAAAAEGp7ocJpInLHbpUd7tNAMhA7PJud6418YzFeRWy/1bUG98Up0Cwg8jWZgnGHB5PVAg==", "c6605aec-ede4-4a1b-97dc-2631f07bef0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "838144ee-b2f8-4101-87d5-3e081317c0fe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf0eea8b-1b7b-4fd5-8617-6eb5cc93d308", "AQAAAAEAACcQAAAAEP6PK7dGCbNqMOzmWLzJkFNX/dsRMns1UfKnRZZtzDwFGb16Zb/no8RpgwoeoEwPKw==", "468c38b5-7885-4f24-acd5-585dff6b0ae5" });
        }
    }
}
