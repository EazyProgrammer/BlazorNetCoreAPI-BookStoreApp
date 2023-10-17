using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListingApp.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Vin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Make", "Model", "Vin" },
                values: new object[,]
                {
                    { 1, "Make 1", "Model 1", "5BC2BB04-6130-4063-8466-5698E6995DBC" },
                    { 2, "Make 2", "Model 2", "3442AEC3-08E5-4FFD-A0F3-FE6E9B82C295" },
                    { 3, "Make 3", "Model 3", "BF8597C3-8C37-4D15-BDC3-F41C85142639" },
                    { 4, "Make 4", "Model 4", "0A65BD4E-3D5E-4684-8984-A0165765ED80" },
                    { 5, "Make 5", "Model 5", "7EF403C9-D8D8-43BB-8A2A-2D8E4BA4DE6A" },
                    { 6, "Make 6", "Model 6", "550B45E1-FC23-491B-A77F-66AB6EA12D5C" },
                    { 7, "Make 7", "Model 7", "422FB740-784C-4C55-9E90-553221F16EC7" },
                    { 8, "Make 8", "Model 8", "EE599366-EE04-49A1-B876-70328153F6EC" },
                    { 9, "Make 9", "Model 9", "CB4FC223-4BE3-46D1-844F-9A1FE11484BA" },
                    { 10, "Make 10", "Model 10", "4A154645-4D68-45FC-B946-12890E8876DB" },
                    { 11, "Make 11", "Model 11", "1F6F8926-47D2-4809-A85C-C12E34FA7006" },
                    { 12, "Make 12", "Model 12", "8088E108-6B10-48D6-81CE-9F0A1D89DFAD" },
                    { 13, "Make 13", "Model 13", "C5EC9C5E-7DA5-438E-9571-5E66548999D2" },
                    { 14, "Make 14", "Model 14", "112B44A3-73BF-43D1-92D4-A96D937B9000" },
                    { 15, "Make 15", "Model 15", "6E4914D1-1E3D-40F6-ACDA-CE68362E7BF5" },
                    { 16, "Make 16", "Model 16", "8BE56BA0-E3F3-4CC6-A7F3-B02F1997BFCF" },
                    { 17, "Make 17", "Model 17", "7912244B-E5A7-4CFC-AECB-B0CF2A598C88" },
                    { 18, "Make 18", "Model 18", "46341A96-A278-41E4-BD2B-7837E2BB62FF" },
                    { 19, "Make 19", "Model 19", "3D1BD3E1-7619-4884-B181-7B8C4FACF025" },
                    { 20, "Make 20", "Model 20", "119B4AB7-9EA5-4DFC-BFFB-971430467D0B" },
                    { 21, "Make 21", "Model 21", "2A02002E-96DE-4C11-9B69-C0AA8187FB37" },
                    { 22, "Make 22", "Model 22", "C2C09EF9-1280-4573-A026-5056F123FF89" },
                    { 23, "Make 23", "Model 23", "60D83FBE-7712-423C-B99E-1A7B253970F5" },
                    { 24, "Make 24", "Model 24", "0B732C49-8FE8-42A6-BCAF-33659EF7FD61" },
                    { 25, "Make 25", "Model 25", "02B1E16D-2A5A-4F48-8820-6CEEDF86F99D" },
                    { 26, "Make 26", "Model 26", "F3777647-D6CE-40CE-90D3-21189B61AB0A" },
                    { 27, "Make 27", "Model 27", "F625ABDD-12A5-4E5C-BB1F-91AD84B5DD63" },
                    { 28, "Make 28", "Model 28", "92C7B501-CE39-4ADD-A337-B2E7DD542F5D" },
                    { 29, "Make 29", "Model 29", "A4751A7B-C9D6-4957-A7CD-B42B97F04FCA" },
                    { 30, "Make 30", "Model 30", "5C4E9E4C-B56C-4E02-9613-FBEFC89B0E5B" },
                    { 31, "Make 31", "Model 31", "B98523E8-BE1C-45F0-A882-AB62374C49E0" },
                    { 32, "Make 32", "Model 32", "72FACFF4-F4A4-43C1-B28C-0E6A71070A87" },
                    { 33, "Make 33", "Model 33", "7BAC7A78-CCBA-48C9-B2F3-DF33EAF1F624" },
                    { 34, "Make 34", "Model 34", "BEC48681-865A-4B0B-8426-6E685678C726" },
                    { 35, "Make 35", "Model 35", "C60387AF-6263-4CB4-AC52-61A446111319" },
                    { 36, "Make 36", "Model 36", "6E602BBC-9484-4FC9-A109-071EDB6B505D" },
                    { 37, "Make 37", "Model 37", "1937651F-4F06-4A02-8359-D70EB1D7B918" },
                    { 38, "Make 38", "Model 38", "D291A402-975D-478E-A969-6FD3C7DE5D46" },
                    { 39, "Make 39", "Model 39", "B3205CA7-58D9-46AA-B0E7-7B93632B0415" },
                    { 40, "Make 40", "Model 40", "17AE704B-96E9-4D23-B85E-E0F7A0A9B441" },
                    { 41, "Make 41", "Model 41", "650C814F-822A-4FE9-B7C6-316AB70E4538" },
                    { 42, "Make 42", "Model 42", "9818539F-8C03-4004-9516-5C455E8ADAF2" },
                    { 43, "Make 43", "Model 43", "8A2C8948-F87E-493F-84F8-0094DFA484CD" },
                    { 44, "Make 44", "Model 44", "179612A1-B286-4629-8610-6ACC2CE31A3F" },
                    { 45, "Make 45", "Model 45", "69EF8B43-EA47-4C5A-BE43-43E21D8765BA" },
                    { 46, "Make 46", "Model 46", "DEA90426-07D8-4EEC-851D-BF6730C07728" },
                    { 47, "Make 47", "Model 47", "1E952196-89CE-48BC-A29C-79F59B494AB4" },
                    { 48, "Make 48", "Model 48", "D50D5CC9-0F7C-4FC4-89D2-0F8CB8D5ED1B" },
                    { 49, "Make 49", "Model 49", "712BBDA6-628A-4C91-B560-AA55B408B018" },
                    { 50, "Make 50", "Model 50", "5AD3AA2F-F9DF-4CC3-8F91-88598B11A6C1" },
                    { 51, "Make 51", "Model 51", "EB15119A-E2C1-464A-B159-B10C51D5E3C7" },
                    { 52, "Make 52", "Model 52", "0CBF30F1-5910-491F-8DF5-FEA6FEE2C6F1" },
                    { 53, "Make 53", "Model 53", "79BC21C0-7850-41CB-A26A-1834660392FE" },
                    { 54, "Make 54", "Model 54", "B19FB9EF-E491-413E-897C-60263F5253F8" },
                    { 55, "Make 55", "Model 55", "900F12BE-6374-482F-8E77-3200B2EBF263" },
                    { 56, "Make 56", "Model 56", "6D9EABCF-118B-44D5-B2ED-60754EBE30C6" },
                    { 57, "Make 57", "Model 57", "42380B4C-FAC4-4808-AFCF-BD7511059AC5" },
                    { 58, "Make 58", "Model 58", "E81708A1-F97D-42B9-A150-60445BA40DD2" },
                    { 59, "Make 59", "Model 59", "A4107172-32CD-4E5C-BAD4-324182EDDE2A" },
                    { 60, "Make 60", "Model 60", "0137EC99-EF7D-4E79-AD54-991B5DF42E6D" },
                    { 61, "Make 61", "Model 61", "64BE24A9-EAB8-4C60-8398-0785400C4287" },
                    { 62, "Make 62", "Model 62", "ABBDAC23-9F7F-4445-87D1-F2CD59C3AF73" },
                    { 63, "Make 63", "Model 63", "F4CB0830-9242-4419-854B-ED60C27D1AD3" },
                    { 64, "Make 64", "Model 64", "B7440982-2F9D-475E-BFC8-4A463248895F" },
                    { 65, "Make 65", "Model 65", "24E61148-34DF-41A0-A141-5E297B2DC432" },
                    { 66, "Make 66", "Model 66", "934037F9-15FD-47C2-AA70-204729A7BBB3" },
                    { 67, "Make 67", "Model 67", "F26CA966-BE8D-4417-BCD2-ED192FF295E1" },
                    { 68, "Make 68", "Model 68", "6FDBD1D8-1CDA-4A8F-A99F-6466A08AD276" },
                    { 69, "Make 69", "Model 69", "0CD9DF06-DB7E-4FFA-A874-4FF220C4E2C0" },
                    { 70, "Make 70", "Model 70", "17F6C7C2-A1B1-46E8-B0CA-4322191F02BF" },
                    { 71, "Make 71", "Model 71", "CAEA0437-2F69-4095-B89A-29DF82C4095A" },
                    { 72, "Make 72", "Model 72", "F7886A8F-2CCB-4CAA-910A-4F754E522F77" },
                    { 73, "Make 73", "Model 73", "6F9313CF-E274-4621-A294-21FDAE78F2AF" },
                    { 74, "Make 74", "Model 74", "40BA7B2B-2F34-49E8-A6EF-043B8C4FA9F7" },
                    { 75, "Make 75", "Model 75", "68DA8B20-4AA8-48CA-A60A-0DF7CC97ACCF" },
                    { 76, "Make 76", "Model 76", "C74D8741-1C08-498F-B277-7FB239C1A412" },
                    { 77, "Make 77", "Model 77", "6923792F-F129-43BD-8322-64659D73D98E" },
                    { 78, "Make 78", "Model 78", "3546B542-B947-4529-A9B1-A72CE8AA2733" },
                    { 79, "Make 79", "Model 79", "B27A1244-3B27-4C64-9E9B-233CAEA8FD51" },
                    { 80, "Make 80", "Model 80", "E21D8325-5079-4702-B341-46E5E2C062D9" },
                    { 81, "Make 81", "Model 81", "98DA9CA0-684E-4B3D-A623-0CA145824C78" },
                    { 82, "Make 82", "Model 82", "BE42535A-8333-4C1B-BF18-5DF245B12777" },
                    { 83, "Make 83", "Model 83", "D7D918C1-A729-4CB0-829C-C3C1CEE367A2" },
                    { 84, "Make 84", "Model 84", "52302A28-889E-4603-9DCD-BCABC2C5B53F" },
                    { 85, "Make 85", "Model 85", "7BC93997-91B0-442A-8292-E8D5778A63D7" },
                    { 86, "Make 86", "Model 86", "727B2E39-7C24-44A0-956C-B583A0C88076" },
                    { 87, "Make 87", "Model 87", "F1B9AF3E-F011-41CD-9467-321E7713CC2C" },
                    { 88, "Make 88", "Model 88", "D6846ED3-CE6C-4D2E-B605-24AFA110C737" },
                    { 89, "Make 89", "Model 89", "FA4CAED1-27C5-4B54-8015-E70E34C8CA4A" },
                    { 90, "Make 90", "Model 90", "BBEB6EE0-155F-4713-A3C4-3B0416763800" },
                    { 91, "Make 91", "Model 91", "1757DC1E-AA8D-4D35-97DA-6CA2A8D60FDF" },
                    { 92, "Make 92", "Model 92", "A0D5BC73-F443-4514-AA8A-346A0E2EA551" },
                    { 93, "Make 93", "Model 93", "FE52C1DF-7CAE-411D-8230-61D2255CF194" },
                    { 94, "Make 94", "Model 94", "43377088-3E0F-4E5B-B7C6-9818DA001977" },
                    { 95, "Make 95", "Model 95", "5AE2E400-0763-45A9-98C0-C2057D71B683" },
                    { 96, "Make 96", "Model 96", "3F5CBF32-55B6-46E4-90F6-FFA9CBC25E59" },
                    { 97, "Make 97", "Model 97", "81BD5C6F-7571-4E50-9C3E-01EDFF799368" },
                    { 98, "Make 98", "Model 98", "88C305D0-2FED-4DF4-B39A-3A03E8B195C9" },
                    { 99, "Make 99", "Model 99", "0C751606-522F-461A-9CC6-FFB029D694E8" },
                    { 100, "Make 100", "Model 100", "51CEE71D-1AA7-465C-A004-4047AA01FBE3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
