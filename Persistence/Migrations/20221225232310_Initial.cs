using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .Annotation("Npgsql:PostgresExtension:ltree", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "optional_designs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    price = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_optional_designs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "site_designs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    price = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site_designs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "site_modules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    price = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site_modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "site_supports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    price = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site_supports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "site_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    price = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_site_types", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "optional_designs");

            migrationBuilder.DropTable(
                name: "site_designs");

            migrationBuilder.DropTable(
                name: "site_modules");

            migrationBuilder.DropTable(
                name: "site_supports");

            migrationBuilder.DropTable(
                name: "site_types");
        }
    }
}
