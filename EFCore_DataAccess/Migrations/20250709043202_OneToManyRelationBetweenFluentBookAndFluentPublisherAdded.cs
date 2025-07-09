using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationBetweenFluentBookAndFluentPublisherAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "TBL_FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_FluentBooks_Publisher_Id",
                table: "TBL_FluentBooks",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_FluentBooks_Fluent_Publishers_Publisher_Id",
                table: "TBL_FluentBooks",
                column: "Publisher_Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_FluentBooks_Fluent_Publishers_Publisher_Id",
                table: "TBL_FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_TBL_FluentBooks_Publisher_Id",
                table: "TBL_FluentBooks");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "TBL_FluentBooks");
        }
    }
}
