using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RuhunaSupply.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    CategoryId1 = table.Column<int>(nullable: false),
                    CategoryId2 = table.Column<int>(nullable: false),
                    CategoryId3 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QtyRequired = table.Column<int>(nullable: false),
                    PurchaseRequestId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    QtySupplied = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    TotalValue = table.Column<double>(nullable: false),
                    EstimatedCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestItemId = table.Column<int>(nullable: false),
                    SpecificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItemSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Faculty = table.Column<int>(nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BudgetAllocation = table.Column<double>(nullable: false),
                    FundGoes = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Project = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Vote = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsInProcumentPlan = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TelephonNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuatationItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuatationId = table.Column<int>(nullable: false),
                    PurchaseRequestItemId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsSupply = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuatationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuatationItemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuatationItemId = table.Column<int>(nullable: false),
                    SpecificationId = table.Column<int>(nullable: false),
                    Satisfied = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuatationItemSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quatations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestId = table.Column<int>(nullable: false),
                    SupplyId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quatations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecificationCategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Descriptiopn = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category2Id = table.Column<int>(nullable: false),
                    RegisterNumber = table.Column<int>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BusinessMail = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    BusinessAddress = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Privileges = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Table = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    PurchaseRequestId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Involvement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPurchaseRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Admin = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    PermissionList = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    MergedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItemSpecifications");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "QuatationItems");

            migrationBuilder.DropTable(
                name: "QuatationItemSpecifications");

            migrationBuilder.DropTable(
                name: "Quatations");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "SpecificationCategories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserNames");

            migrationBuilder.DropTable(
                name: "UserPurchaseRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
