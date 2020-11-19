﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RuhunaSupply.Data;

namespace RuhunaSupply.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RuhunaSupply.Model.Category1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category1s");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Category2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category2s");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Category3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("GPCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GPCategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category3s");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("BudgetAllocation")
                        .HasColumnType("double");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("UsedAmount")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("BudgetAllocation")
                        .HasColumnType("double");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("UsedAmount")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Category1Id")
                        .HasColumnType("int");

                    b.Property<int>("Category2Id")
                        .HasColumnType("int");

                    b.Property<int>("Category3Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Category1Id");

                    b.HasIndex("Category2Id");

                    b.HasIndex("Category3Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RuhunaSupply.Model.PurchaseRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("BudgetAllocation")
                        .HasColumnType("double");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ExaminigId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("FundGoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsInProcumentPlan")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Justification")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Purpose")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SubmittedById")
                        .HasColumnType("int");

                    b.Property<int?>("UserAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Vote")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("_DateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ExaminigId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("SubmittedById");

                    b.HasIndex("UserAccountId");

                    b.ToTable("PurchaseRequests");
                });

            modelBuilder.Entity("RuhunaSupply.Model.PurchaseRequestItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("EstimatedCost")
                        .HasColumnType("double");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseRequestId")
                        .HasColumnType("int");

                    b.Property<int>("QtyRequired")
                        .HasColumnType("int");

                    b.Property<int>("QtySupplied")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.Property<double>("TotalValue")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseRequestId");

                    b.ToTable("PurchaseRequestItems");
                });

            modelBuilder.Entity("RuhunaSupply.Model.PurchaseRequestItemSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseRequestItemId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseRequestItemId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("PurchaseRequestItemSpecifications");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Quatation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PurchaseRequestId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseRequestId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Quatations");
                });

            modelBuilder.Entity("RuhunaSupply.Model.QuatationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IsSupply")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseRequestItemId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int?>("QuatationId")
                        .HasColumnType("int");

                    b.Property<string>("Rate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseRequestItemId");

                    b.HasIndex("QuatationId");

                    b.ToTable("QuatationItems");
                });

            modelBuilder.Entity("RuhunaSupply.Model.QuatationItemSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("QuatationItemId")
                        .HasColumnType("int");

                    b.Property<string>("Satisfied")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("SpecificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuatationItemId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("QuatationItemSpecifications");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SpecificationCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("SpecificationCategoryId");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("RuhunaSupply.Model.SpecificationCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descriptiopn")
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("SpecificationCategories");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BusinessAddress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BusinessCategory")
                        .HasColumnType("int");

                    b.Property<string>("BusinessMail")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BusinessRegisteredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Category2Id")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Category2Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("RuhunaSupply.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("MergedId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionList")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MergedId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RuhunaSupply.Model.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Privileges")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("RuhunaSupply.Model.UserName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Table")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserNames");
                });

            modelBuilder.Entity("RuhunaSupply.Model.UserPurchaseRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Involvement")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPurchaseRequests");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Category2", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Category1", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RuhunaSupply.Model.Category3", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Category1", "GPCategory")
                        .WithMany()
                        .HasForeignKey("GPCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RuhunaSupply.Model.Category2", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RuhunaSupply.Model.Department", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Item", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Category1", "Category1")
                        .WithMany()
                        .HasForeignKey("Category1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RuhunaSupply.Model.Category2", "Category2")
                        .WithMany()
                        .HasForeignKey("Category2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RuhunaSupply.Model.Category3", "Category3")
                        .WithMany()
                        .HasForeignKey("Category3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RuhunaSupply.Model.PurchaseRequest", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("RuhunaSupply.Model.User", "Examinig")
                        .WithMany()
                        .HasForeignKey("ExaminigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RuhunaSupply.Model.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("RuhunaSupply.Model.User", "SubmittedBy")
                        .WithMany()
                        .HasForeignKey("SubmittedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RuhunaSupply.Model.UserAccount", null)
                        .WithMany("PurchaseRequests")
                        .HasForeignKey("UserAccountId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.PurchaseRequestItem", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("RuhunaSupply.Model.PurchaseRequest", "PurchaseRequest")
                        .WithMany()
                        .HasForeignKey("PurchaseRequestId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.PurchaseRequestItemSpecification", b =>
                {
                    b.HasOne("RuhunaSupply.Model.PurchaseRequestItem", "PurchaseRequestItem")
                        .WithMany()
                        .HasForeignKey("PurchaseRequestItemId");

                    b.HasOne("RuhunaSupply.Model.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Quatation", b =>
                {
                    b.HasOne("RuhunaSupply.Model.PurchaseRequest", "PurchaseRequest")
                        .WithMany()
                        .HasForeignKey("PurchaseRequestId");

                    b.HasOne("RuhunaSupply.Model.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.QuatationItem", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("RuhunaSupply.Model.PurchaseRequestItem", "PurchaseRequestItem")
                        .WithMany()
                        .HasForeignKey("PurchaseRequestItemId");

                    b.HasOne("RuhunaSupply.Model.Quatation", "Quatation")
                        .WithMany()
                        .HasForeignKey("QuatationId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.QuatationItemSpecification", b =>
                {
                    b.HasOne("RuhunaSupply.Model.QuatationItem", "QuatationItem")
                        .WithMany()
                        .HasForeignKey("QuatationItemId");

                    b.HasOne("RuhunaSupply.Model.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Specification", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("RuhunaSupply.Model.SpecificationCategory", "SpecificationCategory")
                        .WithMany()
                        .HasForeignKey("SpecificationCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RuhunaSupply.Model.SpecificationCategory", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.Supplier", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Category2", "Category2")
                        .WithMany()
                        .HasForeignKey("Category2Id");
                });

            modelBuilder.Entity("RuhunaSupply.Model.User", b =>
                {
                    b.HasOne("RuhunaSupply.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("RuhunaSupply.Model.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("RuhunaSupply.Model.User", "Merged")
                        .WithMany()
                        .HasForeignKey("MergedId");
                });

            modelBuilder.Entity("RuhunaSupply.Model.UserPurchaseRequest", b =>
                {
                    b.HasOne("RuhunaSupply.Model.PurchaseRequest", "PurchaseRequest")
                        .WithMany()
                        .HasForeignKey("PurchaseRequestId");

                    b.HasOne("RuhunaSupply.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
