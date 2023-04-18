using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsNotification",
                table: "SmsNotification");

            migrationBuilder.RenameTable(
                name: "SmsNotification",
                newName: "SmsNotifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsNotifications",
                table: "SmsNotifications",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsNotifications",
                table: "SmsNotifications");

            migrationBuilder.RenameTable(
                name: "SmsNotifications",
                newName: "SmsNotification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsNotification",
                table: "SmsNotification",
                column: "Id");
        }
    }
}
