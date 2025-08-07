using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace StajOdeviIlkNet8.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: ["Id", "Amount", "Date"],
                values: [1, 500m, new DateTime(2025, 8, 7, 23, 12, 7, 961, DateTimeKind.Local).AddTicks(9374)]);

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: ["Id", "Name"],
                values: new object[,]
                {
                    { 1, "Yumurta" },
                    { 2, "Süt" },
                    { 3, "Yün" },
                    { 4, "Tüy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
