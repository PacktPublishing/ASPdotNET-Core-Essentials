using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PatientRecords.Data.Migrations
{
    public partial class RobotDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Human",
                table: "Human");

            migrationBuilder.CreateTable(
                name: "RobotDoctors",
                columns: table => new
                {
                    RobotDoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelNumber = table.Column<int>(nullable: false),
                    PreferredName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotDoctors", x => x.RobotDoctorId);
                });

            migrationBuilder.AddColumn<int>(
                name: "RobotDoctorId",
                table: "Human",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Humans",
                table: "Human",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_RobotDoctorId",
                table: "Human",
                column: "RobotDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Humans_RobotDoctors_RobotDoctorId",
                table: "Human",
                column: "RobotDoctorId",
                principalTable: "RobotDoctors",
                principalColumn: "RobotDoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Human",
                newName: "Humans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Humans_RobotDoctors_RobotDoctorId",
                table: "Humans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Humans",
                table: "Humans");

            migrationBuilder.DropIndex(
                name: "IX_Humans_RobotDoctorId",
                table: "Humans");

            migrationBuilder.DropColumn(
                name: "RobotDoctorId",
                table: "Humans");

            migrationBuilder.DropTable(
                name: "RobotDoctors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Human",
                table: "Humans",
                column: "ID");

            migrationBuilder.RenameTable(
                name: "Humans",
                newName: "Human");
        }
    }
}
