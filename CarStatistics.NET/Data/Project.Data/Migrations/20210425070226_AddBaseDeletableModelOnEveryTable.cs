namespace Project.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddBaseDeletableModelOnEveryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RepairShops",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RepairShops",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RepairShops",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "RepairShops",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Repairs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Repairs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Repairs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Repairs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Parts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Parts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Parts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Parts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OtherCosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "OtherCosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OtherCosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "OtherCosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairShops_IsDeleted",
                table: "RepairShops",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_IsDeleted",
                table: "Repairs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_IsDeleted",
                table: "Parts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCosts_IsDeleted",
                table: "OtherCosts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IsDeleted",
                table: "Cars",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RepairShops_IsDeleted",
                table: "RepairShops");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_IsDeleted",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Parts_IsDeleted",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_OtherCosts_IsDeleted",
                table: "OtherCosts");

            migrationBuilder.DropIndex(
                name: "IX_Cars_IsDeleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RepairShops");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RepairShops");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RepairShops");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "RepairShops");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "OtherCosts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Cars");
        }
    }
}
