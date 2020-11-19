using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RuhunaSupply.Migrations
{
    public partial class CreateDB : Migration
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
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BudgetAllocation = table.Column<double>(nullable: false),
                    UsedAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
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
                name: "Category2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category2s_Category1s_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BudgetAllocation = table.Column<double>(nullable: false),
                    UsedAmount = table.Column<double>(nullable: false),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category3s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GPCategoryId = table.Column<int>(nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category3s_Category1s_GPCategoryId",
                        column: x => x.GPCategoryId,
                        principalTable: "Category1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category3s_Category2s_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category2Id = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Suppliers_Category2s_Category2Id",
                        column: x => x.Category2Id,
                        principalTable: "Category2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    PermissionList = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    MergedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_MergedId",
                        column: x => x.MergedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Category1Id = table.Column<int>(nullable: false),
                    Category2Id = table.Column<int>(nullable: false),
                    Category3Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Category1s_Category1Id",
                        column: x => x.Category1Id,
                        principalTable: "Category1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Category2s_Category2Id",
                        column: x => x.Category2Id,
                        principalTable: "Category2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Category3s_Category3Id",
                        column: x => x.Category3Id,
                        principalTable: "Category3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
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
                    ExaminigId = table.Column<int>(nullable: false),
                    UserAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Users_ExaminigId",
                        column: x => x.ExaminigId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_Users_SubmittedById",
                        column: x => x.SubmittedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequests_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Descriptiopn = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationCategories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    QtySupplied = table.Column<int>(nullable: false),
                    QtyRequired = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    TotalValue = table.Column<double>(nullable: false),
                    EstimatedCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItems_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quatations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quatations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quatations_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quatations_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    PurchaseRequestId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    Involvement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPurchaseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPurchaseRequests_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPurchaseRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecificationCategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specification_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specification_SpecificationCategories_SpecificationCategoryId",
                        column: x => x.SpecificationCategoryId,
                        principalTable: "SpecificationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuatationItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuatationId = table.Column<int>(nullable: true),
                    PurchaseRequestItemId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsSupply = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuatationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuatationItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuatationItems_PurchaseRequestItems_PurchaseRequestItemId",
                        column: x => x.PurchaseRequestItemId,
                        principalTable: "PurchaseRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuatationItems_Quatations_QuatationId",
                        column: x => x.QuatationId,
                        principalTable: "Quatations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurchaseRequestItemId = table.Column<int>(nullable: true),
                    SpecificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItemSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItemSpecifications_PurchaseRequestItems_Purch~",
                        column: x => x.PurchaseRequestItemId,
                        principalTable: "PurchaseRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItemSpecifications_Specification_Specificatio~",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuatationItemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuatationItemId = table.Column<int>(nullable: true),
                    SpecificationId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuatationItemSpecifications_Specification_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category2s_ParentCategoryId",
                table: "Category2s",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category3s_GPCategoryId",
                table: "Category3s",
                column: "GPCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category3s_ParentCategoryId",
                table: "Category3s",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category1Id",
                table: "Items",
                column: "Category1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category2Id",
                table: "Items",
                column: "Category2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category3Id",
                table: "Items",
                column: "Category3Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItems_ItemId",
                table: "PurchaseRequestItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItems_PurchaseRequestId",
                table: "PurchaseRequestItems",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItemSpecifications_PurchaseRequestItemId",
                table: "PurchaseRequestItemSpecifications",
                column: "PurchaseRequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItemSpecifications_SpecificationId",
                table: "PurchaseRequestItemSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_DepartmentId",
                table: "PurchaseRequests",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_ExaminigId",
                table: "PurchaseRequests",
                column: "ExaminigId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_FacultyId",
                table: "PurchaseRequests",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_SubmittedById",
                table: "PurchaseRequests",
                column: "SubmittedById");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_UserAccountId",
                table: "PurchaseRequests",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItems_ItemId",
                table: "QuatationItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItems_PurchaseRequestItemId",
                table: "QuatationItems",
                column: "PurchaseRequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItems_QuatationId",
                table: "QuatationItems",
                column: "QuatationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItemSpecifications_QuatationItemId",
                table: "QuatationItemSpecifications",
                column: "QuatationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuatationItemSpecifications_SpecificationId",
                table: "QuatationItemSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quatations_PurchaseRequestId",
                table: "Quatations",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Quatations_SupplierId",
                table: "Quatations",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_ItemId",
                table: "Specification",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_SpecificationCategoryId",
                table: "Specification",
                column: "SpecificationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationCategories_ItemId",
                table: "SpecificationCategories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Category2Id",
                table: "Suppliers",
                column: "Category2Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPurchaseRequests_PurchaseRequestId",
                table: "UserPurchaseRequests",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPurchaseRequests_UserId",
                table: "UserPurchaseRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyId",
                table: "Users",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MergedId",
                table: "Users",
                column: "MergedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRequestItemSpecifications");

            migrationBuilder.DropTable(
                name: "QuatationItemSpecifications");

            migrationBuilder.DropTable(
                name: "UserNames");

            migrationBuilder.DropTable(
                name: "UserPurchaseRequests");

            migrationBuilder.DropTable(
                name: "QuatationItems");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItems");

            migrationBuilder.DropTable(
                name: "Quatations");

            migrationBuilder.DropTable(
                name: "SpecificationCategories");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Category3s");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Category2s");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Category1s");
        }
    }
}
