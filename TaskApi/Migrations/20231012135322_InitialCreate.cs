﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TaskApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"TaskItem_Id_seq\"'::regclass)"),
                    Name = table.Column<string>(type: "character(128)", fixedLength: true, maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "character(1024)", fixedLength: true, maxLength: 1024, nullable: true),
                    DueDate = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    CreationDate = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    CompletionDate = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"Users_Id_seq\"'::regclass)"),
                    FirstName = table.Column<string>(type: "character(32)", fixedLength: true, maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "character(32)", fixedLength: true, maxLength: 32, nullable: false),
                    Patronymic = table.Column<string>(type: "character(32)", fixedLength: true, maxLength: 32, nullable: false),
                    Username = table.Column<string>(type: "character(32)", fixedLength: true, maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "character(32)", fixedLength: true, maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "character(32)", fixedLength: true, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
