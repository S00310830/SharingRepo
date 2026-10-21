using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Week2Lab1ConsoleApp2026.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "DateFirstIssued", "Description", "QuantityInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 inch nails", 200, 0.1f },
                    { 2, 1, new DateTime(2019, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 inch bolts", 120, 0.2f },
                    { 3, 2, new DateTime(2019, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chimney Hoover", 10, 100.5f },
                    { 4, 2, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Washing Machine", 7, 399.99f }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "SupplierAddressLine1", "SupplierAddressLine2", "SupplierName" },
                values: new object[,]
                {
                    { 1, "The Coop", "Copersville", "Joe bloggs" },
                    { 2, "Priory Road", "Paris", "Mary Quant" }
                });

            migrationBuilder.InsertData(
                table: "SupplierProducts",
                columns: new[] { "ProductID", "SupplierID", "DateFirstSupplied" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumns: new[] { "ProductID", "SupplierID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumns: new[] { "ProductID", "SupplierID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumns: new[] { "ProductID", "SupplierID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SupplierProducts",
                keyColumns: new[] { "ProductID", "SupplierID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 2);
        }
    }
}
