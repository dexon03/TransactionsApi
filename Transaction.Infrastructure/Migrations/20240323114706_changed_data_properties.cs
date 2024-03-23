using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changed_data_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offset",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "transactionDate",
                table: "transactions",
                newName: "utcTransactionDate");

            migrationBuilder.AddColumn<string>(
                name: "timeZoneId",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeZoneId",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "utcTransactionDate",
                table: "transactions",
                newName: "transactionDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "offset",
                table: "transactions",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
