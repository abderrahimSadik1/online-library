using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblio.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Subscribers_SubscriberID",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriberID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Subscribers_SubscriberID",
                table: "Reservations",
                column: "SubscriberID",
                principalTable: "Subscribers",
                principalColumn: "SubscriberID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Subscribers_SubscriberID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriberID",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Subscribers_SubscriberID",
                table: "Reservations",
                column: "SubscriberID",
                principalTable: "Subscribers",
                principalColumn: "SubscriberID");
        }
    }
}
