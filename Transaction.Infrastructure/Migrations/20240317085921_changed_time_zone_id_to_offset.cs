using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changed_time_zone_id_to_offset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeZoneId",
                table: "transactions");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "offset",
                table: "transactions",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offset",
                table: "transactions");

            migrationBuilder.AddColumn<string>(
                name: "timeZoneId",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
