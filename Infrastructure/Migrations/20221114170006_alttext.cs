using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class alttext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageAltText",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e17e-3b0e-446f-86af-438d56fd7210",
                column: "ConcurrencyStamp",
                value: "8a7a6a18-4332-4f2c-a11b-77b61e15c6a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e17e-3b0e-446f-86af-438d56fd7211",
                column: "ConcurrencyStamp",
                value: "0e7fd26c-4643-4d7a-8980-89ba0f78b3ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d047cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb056d72-54e6-4a37-817c-5fdd3204ea12", "AQAAAAEAACcQAAAAEArFenUO94yAgwE8qOuVox8w65m2Gc7Y2iGRZatskBrelj1+9Jm9i7vpJGjGkv7uXQ==", "e0066419-e631-44a3-847c-b9591e035e44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d047des3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96e227c7-460a-43a4-aade-cf074a447cf6", "AQAAAAEAACcQAAAAEFBlGOtR25P2nZqao3dnucsHaV7nZfpw7DA/mIvJ26L+sjMSJGEU9yU6NsM4OVbBrA==", "bf504a35-e518-41ce-8477-f753fc4007c5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAltText",
                table: "Animal");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e17e-3b0e-446f-86af-438d56fd7210",
                column: "ConcurrencyStamp",
                value: "c5e61bd8-2387-4b9a-879c-d31690158a4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e17e-3b0e-446f-86af-438d56fd7211",
                column: "ConcurrencyStamp",
                value: "affa72d4-2140-4fc9-8b10-ae414059ea31");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d047cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e96314c-d5f7-41ef-b1f6-a0636f319e2b", "AQAAAAEAACcQAAAAEIudsb/ThmdvDjJ7xDPVOWApn4hYSdKLTON5YWpcAn1ZrN0e2Cl70FSzg+VKZisecA==", "7e581ff6-8860-4d21-97ee-8416f3f50be4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d047des3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef82a10d-d875-4a06-82b6-f81921166c8e", "AQAAAAEAACcQAAAAEIct7EZ58j0/kB/LRsfmtTSxGSQqeWcEXFV6HpmDPYiBh6NIwJb3eFi/CWxGjfXA9A==", "2d87ecab-20eb-4cf1-ad41-dc827b5c55b3" });
        }
    }
}
