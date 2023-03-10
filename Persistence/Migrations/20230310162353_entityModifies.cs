using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityModifies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateLastModify",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "UserModifierId",
                table: "Candidates",
                newName: "ModifiedBy");

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "QuestionsAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "QuestionsAnswers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Phones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Phones",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Emails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Emails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Certifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Certifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Candidates",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "QuestionsAnswers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "QuestionsAnswers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Candidates",
                newName: "UserModifierId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModify",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
