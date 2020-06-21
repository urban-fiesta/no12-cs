using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrbanFiesta.Migrations
{
    public partial class UpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CensusraIdade",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Events",
                newName: "local");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ageLimit",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "eventPhoto",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "finish",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Events",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "Events",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "start",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "tag",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ageLimit",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "eventPhoto",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "finish",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "tag",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "local",
                table: "Events",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CensusraIdade",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Events",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "Events",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
