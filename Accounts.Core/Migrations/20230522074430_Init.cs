using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountFiscalYear",
                columns: table => new
                {
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FiscalYearName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FiscalYearStart = table.Column<DateTime>(type: "date", nullable: false),
                    FiscalYearEnd = table.Column<DateTime>(type: "date", nullable: false),
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
                    table.PrimaryKey("PK_FiscalYear", x => x.FiscalYearId);
                });

            migrationBuilder.CreateTable(
                name: "AccountHeadType",
                columns: table => new
                {
                    AcHeadTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcHeadTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcHeadTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_AccountHeadType", x => x.AcHeadTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransType",
                columns: table => new
                {
                    AcTransTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcTransTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_CV", x => x.AcTransTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AccountVoucherType",
                columns: table => new
                {
                    AcVoucherTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcVoucherTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_AccountVoucherType", x => x.AcVoucherTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCodeSuffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateProvinceId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_City", x => x.CityId);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilLevels", x => x.CivilLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencySign = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductCategoryCode = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubCategory",
                columns: table => new
                {
                    ProductSubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSubCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductSubCategoryCode = table.Column<long>(type: "bigint", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProductSubCategory", x => x.ProductSubCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => new { x.Id, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                columns: table => new
                {
                    StateProvinceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateProvinceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_StateProvince", x => x.StateProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AccountHeads",
                columns: table => new
                {
                    AcHeadId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcHeadCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcHeadName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcHeadTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heads", x => x.AcHeadId);
                    table.ForeignKey(
                        name: "FK_AccountHeads_AccountHeadType",
                        column: x => x.AcHeadTypeId,
                        principalTable: "AccountHeadType",
                        principalColumn: "AcHeadTypeId");
                });

            migrationBuilder.CreateTable(
                name: "AccountTransMaster",
                columns: table => new
                {
                    AcTransMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcTransTypeId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    AcTransDate = table.Column<DateTime>(type: "date", nullable: false),
                    AcDocNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AccountTransMaster", x => x.AcTransMasterId);
                    table.ForeignKey(
                        name: "FK_AccountTransMaster_AccountTransType",
                        column: x => x.AcTransTypeId,
                        principalTable: "AccountTransType",
                        principalColumn: "AcTransTypeId");
                });

            migrationBuilder.CreateTable(
                name: "AccountVoucherMaster",
                columns: table => new
                {
                    AcVoucherMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcVoucherTypeId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    AcTransDate = table.Column<DateTime>(type: "date", nullable: false),
                    AcDocNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AccountVoucherMaster", x => x.AcVoucherMasterId);
                    table.ForeignKey(
                        name: "FK_AccountVoucherMaster_AccountVoucherType",
                        column: x => x.AcVoucherTypeId,
                        principalTable: "AccountVoucherType",
                        principalColumn: "AcVoucherTypeId");
                });

            migrationBuilder.CreateTable(
                name: "CivilEntities",
                columns: table => new
                {
                    CivilEntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilEntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivilLevelId = table.Column<int>(type: "int", nullable: false),
                    CivilParentId = table.Column<long>(type: "bigint", nullable: true),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AccountControls",
                columns: table => new
                {
                    AcControlId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcControlCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcControlName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcHeadId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.AcControlId);
                    table.ForeignKey(
                        name: "FK_AccountControls_AccountHeads",
                        column: x => x.AcHeadId,
                        principalTable: "AccountHeads",
                        principalColumn: "AcHeadId");
                });

            migrationBuilder.CreateTable(
                name: "AccountTransDetail",
                columns: table => new
                {
                    AcTransDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcTransMasterId = table.Column<long>(type: "bigint", nullable: false),
                    PayeeAcLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    PayeeAcSubLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    PayeeAcContactId = table.Column<long>(type: "bigint", nullable: false),
                    PayeeRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChqNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChqDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReceiverAcLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverAcSubLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverAcContactId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
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
                    table.PrimaryKey("PK_AccountTransactionDetail", x => x.AcTransDetailId);
                    table.ForeignKey(
                        name: "FK_AccountTransDetail_AccountTransMaster",
                        column: x => x.AcTransMasterId,
                        principalTable: "AccountTransMaster",
                        principalColumn: "AcTransMasterId");
                });

            migrationBuilder.CreateTable(
                name: "AccountVoucherDetail",
                columns: table => new
                {
                    AcVoucherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcVoucherMasterId = table.Column<long>(type: "bigint", nullable: false),
                    AcLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    AcSubLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
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
                    table.PrimaryKey("PK_AcVoucher", x => x.AcVoucherId);
                    table.ForeignKey(
                        name: "FK_AccountVoucherDetail_AccountVoucherMaster1",
                        column: x => x.AcVoucherMasterId,
                        principalTable: "AccountVoucherMaster",
                        principalColumn: "AcVoucherMasterId");
                });

            migrationBuilder.CreateTable(
                name: "CivilEntitiesCurrencies",
                columns: table => new
                {
                    CivilEntitiesCurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilEntitiesCurrencies", x => x.CivilEntitiesCurrencyId);
                    table.ForeignKey(
                        name: "FK_CivilEntitiesCurrencies_CivilEntities",
                        column: x => x.CivilEntityId,
                        principalTable: "CivilEntities",
                        principalColumn: "CivilEntityId");
                    table.ForeignKey(
                        name: "FK_CivilEntitiesCurrencies_Currencies",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                });

            migrationBuilder.CreateTable(
                name: "CivilEntitiesLanguages",
                columns: table => new
                {
                    CivilEntitiessLanguagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilEntitiesLanguages", x => x.CivilEntitiessLanguagesId);
                    table.ForeignKey(
                        name: "FK_CivilEntitiesLanguages_CivilEntities",
                        column: x => x.CivilEntityId,
                        principalTable: "CivilEntities",
                        principalColumn: "CivilEntityId");
                    table.ForeignKey(
                        name: "FK_CivilEntitiesLanguages_Languages",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId");
                });

            migrationBuilder.CreateTable(
                name: "AccountLedger",
                columns: table => new
                {
                    AcLedgerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcLedgerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcLedgerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcControlId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Createdby = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.AcLedgerId);
                    table.ForeignKey(
                        name: "FK_AccountLedger_AccountControls",
                        column: x => x.AcControlId,
                        principalTable: "AccountControls",
                        principalColumn: "AcControlId");
                });

            migrationBuilder.CreateTable(
                name: "AccountProfile",
                columns: table => new
                {
                    AcProfileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChqName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tel1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cell1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cell2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NTN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    STRN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    PostedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.AcProfileId);
                    table.ForeignKey(
                        name: "FK_AccountProfile_AccountLedger",
                        column: x => x.AcLedgerId,
                        principalTable: "AccountLedger",
                        principalColumn: "AcLedgerId");
                    table.ForeignKey(
                        name: "FK_AccountProfile_Currencies",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                });

            migrationBuilder.CreateTable(
                name: "AccountSubLedger",
                columns: table => new
                {
                    AcSubLedgerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcSubLedgerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcSubLedgerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcLedgerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TotalRows = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgers", x => x.AcSubLedgerId);
                    table.ForeignKey(
                        name: "FK_AccountSubLedger_AccountLedger",
                        column: x => x.AcLedgerId,
                        principalTable: "AccountLedger",
                        principalColumn: "AcLedgerId");
                });

            migrationBuilder.CreateTable(
                name: "AccountContact",
                columns: table => new
                {
                    AcContactId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cell1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cell2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NTN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    STRN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_Contact", x => x.AcContactId);
                    table.ForeignKey(
                        name: "FK_AccountContact_AccountProfile",
                        column: x => x.AcProfileId,
                        principalTable: "AccountProfile",
                        principalColumn: "AcProfileId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false),
                    AcProfileId = table.Column<long>(type: "bigint", nullable: true),
                    AcContactId = table.Column<long>(type: "bigint", nullable: true),
                    Long = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilEntityId = table.Column<long>(type: "bigint", nullable: false),
                    Line5 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Line4 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_AccountContact",
                        column: x => x.AcContactId,
                        principalTable: "AccountContact",
                        principalColumn: "AcContactId");
                    table.ForeignKey(
                        name: "FK_Address_AccountProfile",
                        column: x => x.AcProfileId,
                        principalTable: "AccountProfile",
                        principalColumn: "AcProfileId");
                    table.ForeignKey(
                        name: "FK_Address_AddressType",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId");
                    table.ForeignKey(
                        name: "FK_Address_CivilEntities",
                        column: x => x.CivilEntityId,
                        principalTable: "CivilEntities",
                        principalColumn: "CivilEntityId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_AcProfileId",
                table: "AccountContact",
                column: "AcProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountControls_AcHeadId",
                table: "AccountControls",
                column: "AcHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHeads_AcHeadTypeId",
                table: "AccountHeads",
                column: "AcHeadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLedger_AcControlId",
                table: "AccountLedger",
                column: "AcControlId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfile_AcLedgerId",
                table: "AccountProfile",
                column: "AcLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfile_CurrencyId",
                table: "AccountProfile",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubLedger_AcLedgerId",
                table: "AccountSubLedger",
                column: "AcLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransDetail_AcTransMasterId",
                table: "AccountTransDetail",
                column: "AcTransMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransMaster_AcTransTypeId",
                table: "AccountTransMaster",
                column: "AcTransTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountVoucherDetail_AcVoucherMasterId",
                table: "AccountVoucherDetail",
                column: "AcVoucherMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountVoucherMaster_AcVoucherTypeId",
                table: "AccountVoucherMaster",
                column: "AcVoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AcContactId",
                table: "Address",
                column: "AcContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AcProfileId",
                table: "Address",
                column: "AcProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressTypeId",
                table: "Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CivilEntityId",
                table: "Address",
                column: "CivilEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilEntities_CivilLevelId",
                table: "CivilEntities",
                column: "CivilLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilEntitiesCurrencies_CivilEntityId",
                table: "CivilEntitiesCurrencies",
                column: "CivilEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilEntitiesCurrencies_CurrencyId",
                table: "CivilEntitiesCurrencies",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilEntitiesLanguages_CivilEntityId",
                table: "CivilEntitiesLanguages",
                column: "CivilEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilEntitiesLanguages_LanguageId",
                table: "CivilEntitiesLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountFiscalYear");

            migrationBuilder.DropTable(
                name: "AccountSubLedger");

            migrationBuilder.DropTable(
                name: "AccountTransDetail");

            migrationBuilder.DropTable(
                name: "AccountVoucherDetail");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CivilEntitiesCurrencies");

            migrationBuilder.DropTable(
                name: "CivilEntitiesLanguages");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductSubCategory");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StateProvince");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AccountTransMaster");

            migrationBuilder.DropTable(
                name: "AccountVoucherMaster");

            migrationBuilder.DropTable(
                name: "AccountContact");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "CivilEntities");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "AccountTransType");

            migrationBuilder.DropTable(
                name: "AccountVoucherType");

            migrationBuilder.DropTable(
                name: "AccountProfile");

            migrationBuilder.DropTable(
                name: "CivilLevels");

            migrationBuilder.DropTable(
                name: "AccountLedger");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "AccountControls");

            migrationBuilder.DropTable(
                name: "AccountHeads");

            migrationBuilder.DropTable(
                name: "AccountHeadType");
        }
    }
}
