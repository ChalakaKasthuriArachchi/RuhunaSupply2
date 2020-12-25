using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RuhunaSupply.Migrations
{
    public partial class jj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category3s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GPCategoryId = table.Column<int>(nullable: false),
                    ParentCategoryId = table.Column<int>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category3s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    BudgetAllocation = table.Column<double>(nullable: false),
                    UsedAmount = table.Column<double>(nullable: false),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    BudgetAllocation = table.Column<double>(nullable: false),
                    UsedAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category1Id = table.Column<int>(nullable: false),
                    Category2Id = table.Column<int>(nullable: false),
                    Category3Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FacultyId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    BudgetAllocation = table.Column<double>(nullable: false),
                    FundGoes = table.Column<string>(nullable: true),
                    Project = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Vote = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsInProcumentPlan = table.Column<bool>(nullable: false),
                    Purpose = table.Column<int>(nullable: false),
                    _DateTime = table.Column<DateTime>(nullable: false),
                    Justification = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SubmittedById = table.Column<int>(nullable: false),
                    ExaminigId = table.Column<int>(nullable: false)
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
                    QuotationId = table.Column<int>(nullable: false),
                    PurchaseRequestItemId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsSupplied = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Qty = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuatationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: true)
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
                    RegistrationNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    BusinessRegisteredDate = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BusinessMail = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    BusinessAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BusinessCategory = table.Column<int>(nullable: false)
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
                    HashedPassword = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
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
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
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
                    FacultyId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    QtySupplied = table.Column<double>(nullable: false),
                    QtyRequired = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    TotalValue = table.Column<double>(nullable: false),
                    EstimatedCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestItemId = table.Column<int>(nullable: false),
                    SpecificationCategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    QuatationItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specification_QuatationItems_QuatationItemId",
                        column: x => x.QuatationItemId,
                        principalTable: "QuatationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestItemId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItemSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItemSpecifications_PurchaseRequestItems_Purch~",
                        column: x => x.PurchaseRequestItemId,
                        principalTable: "PurchaseRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_QuatationItemSpecifications_QuatationItems_QuatationItemId",
                        column: x => x.QuatationItemId,
                        principalTable: "QuatationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuatationItemSpecifications_Specification_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItems_PurchaseRequestId",
                table: "PurchaseRequestItems",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItemSpecifications_PurchaseRequestItemId",
                table: "PurchaseRequestItemSpecifications",
                column: "PurchaseRequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItemSpecifications_QuatationItemId",
                table: "QuatationItemSpecifications",
                column: "QuatationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItemSpecifications_SpecificationId",
                table: "QuatationItemSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_QuatationItemId",
                table: "Specification",
                column: "QuatationItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category1s");

            migrationBuilder.DropTable(
                name: "Category2s");

            migrationBuilder.DropTable(
                name: "Category3s");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItemSpecifications");

            migrationBuilder.DropTable(
                name: "QuatationItemSpecifications");

            migrationBuilder.DropTable(
                name: "Quotations");

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

            migrationBuilder.DropTable(
                name: "PurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "QuatationItems");
        }
    }
}
