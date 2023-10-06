﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proje1.Persistence.Context;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    [DbContext(typeof(ProjeContext))]
    [Migration("20231006072510_mig8")]
    partial class mig8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proje1.Domain.Entities.Authority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Accounting")
                        .HasColumnType("bit")
                        .HasColumnName("IS_ACCOUNTING")
                        .HasColumnOrder(8);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit")
                        .HasColumnName("IS_ADMIN")
                        .HasColumnOrder(3);

                    b.Property<bool>("Approve")
                        .HasColumnType("bit")
                        .HasColumnName("IS_APPROVE")
                        .HasColumnOrder(6);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID")
                        .HasColumnOrder(2);

                    b.Property<bool>("Receive")
                        .HasColumnType("bit")
                        .HasColumnName("IS_RECEIVE")
                        .HasColumnOrder(7);

                    b.Property<bool>("Request")
                        .HasColumnType("bit")
                        .HasColumnName("IS_REQUEST")
                        .HasColumnOrder(5);

                    b.Property<bool>("management")
                        .HasColumnType("bit")
                        .HasColumnName("IS_MANAGEMENT")
                        .HasColumnOrder(9);

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("AUTHORITY", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("COMPANY_NAME")
                        .HasColumnOrder(2);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("COMPANY", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("COMPANY_ID")
                        .HasColumnOrder(2);

                    b.Property<string>("DepartmantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("DEPARTMANT_NAME")
                        .HasColumnOrder(3);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("DEPARTMENT", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("COMPANY_NAME")
                        .HasColumnOrder(4);

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CREATE_BY")
                        .HasColumnOrder(36);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(37);

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("INVOICE_DATE")
                        .HasColumnOrder(3);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(38);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(39);

                    b.Property<string>("ProductDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PRODUCT_DETAİL")
                        .HasColumnOrder(5);

                    b.Property<int>("RequestFormId")
                        .HasColumnType("int")
                        .HasColumnName("REQUESTFROM_ID")
                        .HasColumnOrder(2);

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float")
                        .HasColumnName("TOTAL_PRİCE")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("RequestFormId");

                    b.ToTable("INVOICES", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ADDRESS")
                        .HasColumnOrder(5);

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("COMPANY_EMAİL")
                        .HasColumnOrder(6);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("COMPANY_NAME")
                        .HasColumnOrder(4);

                    b.Property<string>("CompanyPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("COMPANY_PHONE")
                        .HasColumnOrder(7);

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CREATE_BY")
                        .HasColumnOrder(36);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(37);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(38);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(39);

                    b.Property<int>("RequestformId")
                        .HasColumnType("int")
                        .HasColumnName("REQUESTFORM_ID")
                        .HasColumnOrder(3);

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float")
                        .HasColumnName("TOTAL_PRICE")
                        .HasColumnOrder(8);

                    b.HasKey("Id");

                    b.HasIndex("RequestformId");

                    b.ToTable("OFFERS", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("EMAİL")
                        .HasColumnOrder(6);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(4);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSWORD")
                        .HasColumnOrder(8);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("SURNAME")
                        .HasColumnOrder(5);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("USERNAME")
                        .HasColumnOrder(7);

                    b.Property<int>("departmantId")
                        .HasColumnType("int")
                        .HasColumnName("DEPARTMENT_ID")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("departmantId");

                    b.ToTable("PERSONS", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CREATE_BY")
                        .HasColumnOrder(36);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(37);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(38);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(39);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(2);

                    b.Property<string>("ProductDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("PRODUCTDETAİL")
                        .HasColumnOrder(3);

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("STOCK")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE")
                        .HasColumnOrder(5);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DEPARTMENT_ID")
                        .HasColumnOrder(3);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID")
                        .HasColumnOrder(2);

                    b.Property<string>("detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DETAİL")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PersonId");

                    b.ToTable("REPORTS", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.RequestForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CREATE_BY")
                        .HasColumnOrder(36);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(37);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DETAİL")
                        .HasColumnOrder(4);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(40)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(38);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(39);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(3);

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID")
                        .HasColumnOrder(2);

                    b.Property<string>("Products")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COMPANY_EMAİL")
                        .HasColumnOrder(5);

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("STATUS")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("REQUESTFORM", (string)null);
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Authority", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.Person", "Person")
                        .WithOne("Authority")
                        .HasForeignKey("Proje1.Domain.Entities.Authority", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Department", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.RequestForm", "RequestForm")
                        .WithMany("Invoices")
                        .HasForeignKey("RequestFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestForm");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Offer", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.RequestForm", "RequestForm")
                        .WithMany("Offers")
                        .HasForeignKey("RequestformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestForm");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Person", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.Department", "Department")
                        .WithMany("Persons")
                        .HasForeignKey("departmantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("PERSONS_Department_DEPARTMENT_ID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Report", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.Department", "Department")
                        .WithMany("Reports")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proje1.Domain.Entities.Person", "Person")
                        .WithMany("Reports")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.RequestForm", b =>
                {
                    b.HasOne("Proje1.Domain.Entities.Person", "Person")
                        .WithMany("RequestForms")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Company", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Department", b =>
                {
                    b.Navigation("Persons");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.Person", b =>
                {
                    b.Navigation("Authority")
                        .IsRequired();

                    b.Navigation("Reports");

                    b.Navigation("RequestForms");
                });

            modelBuilder.Entity("Proje1.Domain.Entities.RequestForm", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
