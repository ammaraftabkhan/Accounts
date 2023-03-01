using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Core.Migrations
{
    public partial class AccountsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Area",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Area_City",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_City_StateProvince",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_StateProvince_Country",
                table: "StateProvince");

            migrationBuilder.DropIndex(
                name: "IX_StateProvince_CountryId",
                table: "StateProvince");

            migrationBuilder.DropIndex(
                name: "IX_City_StateProvinceId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Area_CityId",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Address_AreaId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.AddColumn<int>(
                name: "CivilEntityId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "FiscalYearId",
                table: "AccountVoucherMaster",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "FiscalYearId",
                table: "AccountTransMaster",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AcSubLedgerCode",
                table: "AccountSubLedger",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "AcLedgerCode",
                table: "AccountLedger",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "AcHeadCode",
                table: "AccountHeads",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FiscalYearId",
                table: "AccountFiscalYear",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "AcControlCode",
                table: "AccountControls",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.CreateTable(
                name: "CivilEntitiesCurrencies",
                columns: table => new
                {
                    CivilEntitiesCurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilEntityId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilEntitiesCurrencies", x => x.CivilEntitiesCurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CivilEntitiesLanguages",
                columns: table => new
                {
                    CivilEntitiessLanguagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilEntityId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilEntitiesLanguages", x => x.CivilEntitiessLanguagesId);
                });

            migrationBuilder.CreateTable(
                name: "CivilLevels",
                columns: table => new
                {
                    CivilLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilLevelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilLevels", x => x.CivilLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "CivilEntities",
                columns: table => new
                {
                    CivilEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilEntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilLevelId = table.Column<int>(type: "int", nullable: false),
                    CivilParentId = table.Column<int>(type: "int", nullable: false),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilEntities", x => x.CivilEntityId);
                    table.ForeignKey(
                        name: "FK_CivilEntities_CivilLevels",
                        column: x => x.CivilLevelId,
                        principalTable: "CivilLevels",
                        principalColumn: "CivilLevelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CivilEntityId",
                table: "Address",
                column: "CivilEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilEntities_CivilLevelId",
                table: "CivilEntities",
                column: "CivilLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_CivilEntities",
                table: "Address",
                column: "CivilEntityId",
                principalTable: "CivilEntities",
                principalColumn: "CivilEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_CivilEntities",
                table: "Address");

            migrationBuilder.DropTable(
                name: "CivilEntities");

            migrationBuilder.DropTable(
                name: "CivilEntitiesCurrencies");

            migrationBuilder.DropTable(
                name: "CivilEntitiesLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "CivilLevels");

            migrationBuilder.DropIndex(
                name: "IX_Address_CivilEntityId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CivilEntityId",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.AddColumn<long>(
                name: "AreaId",
                table: "Address",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "AccountVoucherMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "AccountTransMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AcSubLedgerCode",
                table: "AccountSubLedger",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<long>(
                name: "AcLedgerCode",
                table: "AccountLedger",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<long>(
                name: "AcHeadCode",
                table: "AccountHeads",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "AccountFiscalYear",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "AcControlCode",
                table: "AccountControls",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryId",
                table: "StateProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateProvinceId",
                table: "City",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CityId",
                table: "Area",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AreaId",
                table: "Address",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Area",
                table: "Address",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_City",
                table: "Area",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_StateProvince",
                table: "City",
                column: "StateProvinceId",
                principalTable: "StateProvince",
                principalColumn: "StateProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StateProvince_Country",
                table: "StateProvince",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId");
        }
    }
}
