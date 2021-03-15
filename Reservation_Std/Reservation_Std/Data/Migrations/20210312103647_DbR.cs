using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation_Std.Data.Migrations
{
    public partial class DbR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email_Utilisateur",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_Utilisateur",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nombre_reservation",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblType_Reservation",
                columns: table => new
                {
                    IdType_reservation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblType_Reservation", x => x.IdType_reservation);
                });

            migrationBuilder.CreateTable(
                name: "tblReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    UtilisateurId = table.Column<string>(nullable: true),
                    ReservationTypeIdType_reservation = table.Column<int>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblReservation_tblType_Reservation_ReservationTypeIdType_reservation",
                        column: x => x.ReservationTypeIdType_reservation,
                        principalTable: "tblType_Reservation",
                        principalColumn: "IdType_reservation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReservation_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblReservation_ReservationTypeIdType_reservation",
                table: "tblReservation",
                column: "ReservationTypeIdType_reservation");

            migrationBuilder.CreateIndex(
                name: "IX_tblReservation_UtilisateurId",
                table: "tblReservation",
                column: "UtilisateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblReservation");

            migrationBuilder.DropTable(
                name: "tblType_Reservation");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Email_Utilisateur",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID_Utilisateur",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre_reservation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");
        }
    }
}
