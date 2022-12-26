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
                name: "development_timelines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    multiplicationfactor = table.Column<double>(name: "multiplication_factor", type: "double precision", nullable: false, defaultValue: 0.0),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_development_timelines", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    role = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, defaultValue: "user"),
                    phone = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "Not found"),
                    firstname = table.Column<string>(name: "first_name", type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "Not found"),
                    middlename = table.Column<string>(name: "middle_name", type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "Not found"),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offernumber = table.Column<int>(name: "offer_number", type: "integer", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: false),
                    sitetypeid = table.Column<int>(name: "site_type_id", type: "integer", nullable: false),
                    sitedesignid = table.Column<int>(name: "site_design_id", type: "integer", nullable: false),
                    orderdate = table.Column<DateTime>(name: "order_date", type: "timestamp with time zone", nullable: false),
                    comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false, defaultValue: ""),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offers", x => x.id);
                    table.ForeignKey(
                        name: "fk_offers_site_designs_site_design_id",
                        column: x => x.sitedesignid,
                        principalTable: "site_designs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offers_site_types_site_type_id",
                        column: x => x.sitetypeid,
                        principalTable: "site_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offers_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offer_modules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(name: "offer_id", type: "uuid", nullable: false),
                    sitemodulesid = table.Column<int>(name: "site_modules_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offer_modules", x => x.id);
                    table.ForeignKey(
                        name: "fk_offer_modules_offers_offer_id",
                        column: x => x.offerid,
                        principalTable: "offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offer_modules_site_modules_site_modules_id",
                        column: x => x.sitemodulesid,
                        principalTable: "site_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offer_optional_designs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(name: "offer_id", type: "uuid", nullable: false),
                    optionaldesignid = table.Column<int>(name: "optional_design_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offer_optional_designs", x => x.id);
                    table.ForeignKey(
                        name: "fk_offer_optional_designs_offers_offer_id",
                        column: x => x.offerid,
                        principalTable: "offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offer_optional_designs_optional_designs_optional_design_id",
                        column: x => x.optionaldesignid,
                        principalTable: "optional_designs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offer_supports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(name: "offer_id", type: "uuid", nullable: false),
                    sitesupportid = table.Column<int>(name: "site_support_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offer_supports", x => x.id);
                    table.ForeignKey(
                        name: "fk_offer_supports_offers_offer_id",
                        column: x => x.offerid,
                        principalTable: "offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offer_supports_site_supports_site_support_id",
                        column: x => x.sitesupportid,
                        principalTable: "site_supports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(name: "offer_id", type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    agreement = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastmodifiedby = table.Column<string>(name: "last_modified_by", type: "text", nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_offers_offer_id",
                        column: x => x.offerid,
                        principalTable: "offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orders_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_offer_modules_offer_id",
                table: "offer_modules",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_modules_site_modules_id",
                table: "offer_modules",
                column: "site_modules_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_optional_designs_offer_id",
                table: "offer_optional_designs",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_optional_designs_optional_design_id",
                table: "offer_optional_designs",
                column: "optional_design_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_supports_offer_id",
                table: "offer_supports",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_supports_site_support_id",
                table: "offer_supports",
                column: "site_support_id");

            migrationBuilder.CreateIndex(
                name: "ix_offers_offer_number",
                table: "offers",
                column: "offer_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_offers_site_design_id",
                table: "offers",
                column: "site_design_id");

            migrationBuilder.CreateIndex(
                name: "ix_offers_site_type_id",
                table: "offers",
                column: "site_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_offers_user_id",
                table: "offers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_offer_id",
                table: "orders",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_phone",
                table: "users",
                column: "phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "development_timelines");

            migrationBuilder.DropTable(
                name: "offer_modules");

            migrationBuilder.DropTable(
                name: "offer_optional_designs");

            migrationBuilder.DropTable(
                name: "offer_supports");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "site_modules");

            migrationBuilder.DropTable(
                name: "optional_designs");

            migrationBuilder.DropTable(
                name: "site_supports");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "site_designs");

            migrationBuilder.DropTable(
                name: "site_types");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
