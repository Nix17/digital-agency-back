using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "development_timeline_id",
                table: "offers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_offers_development_timeline_id",
                table: "offers",
                column: "development_timeline_id");

            migrationBuilder.AddForeignKey(
                name: "fk_offers_development_timelines_development_timeline_id",
                table: "offers",
                column: "development_timeline_id",
                principalTable: "development_timelines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_offers_development_timelines_development_timeline_id",
                table: "offers");

            migrationBuilder.DropIndex(
                name: "ix_offers_development_timeline_id",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "development_timeline_id",
                table: "offers");
        }
    }
}
