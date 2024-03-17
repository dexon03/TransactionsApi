using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamed_columns_changed_offset_to_time_zone_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offset",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "transaction_date",
                table: "transactions",
                newName: "transactionDate");

            migrationBuilder.RenameColumn(
                name: "client_location",
                table: "transactions",
                newName: "clientLocation");

            migrationBuilder.RenameColumn(
                name: "transaction_id",
                table: "transactions",
                newName: "transactionId");

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
                name: "transactionDate",
                table: "transactions",
                newName: "transaction_date");

            migrationBuilder.RenameColumn(
                name: "clientLocation",
                table: "transactions",
                newName: "client_location");

            migrationBuilder.RenameColumn(
                name: "transactionId",
                table: "transactions",
                newName: "transaction_id");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "offset",
                table: "transactions",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
