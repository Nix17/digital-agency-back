﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221226204127_NewTables_26_12_2022")]
    partial class NewTables26122022
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "ltree");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_stat_statements");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.DevelopmentTimelineEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<double>("MultiplicationFactor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("multiplication_factor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_development_timelines");

                    b.ToTable("development_timelines", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OfferEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasDefaultValue("")
                        .HasColumnName("comment");

                    b.Property<double>("Cost")
                        .HasColumnType("double precision")
                        .HasColumnName("cost");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<int>("OfferNumber")
                        .HasColumnType("integer")
                        .HasColumnName("offer_number");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_date");

                    b.Property<int>("SiteDesignId")
                        .HasColumnType("integer")
                        .HasColumnName("site_design_id");

                    b.Property<int>("SiteTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("site_type_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_offers");

                    b.HasIndex("OfferNumber")
                        .IsUnique()
                        .HasDatabaseName("ix_offers_offer_number");

                    b.HasIndex("SiteDesignId")
                        .HasDatabaseName("ix_offers_site_design_id");

                    b.HasIndex("SiteTypeId")
                        .HasDatabaseName("ix_offers_site_type_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_offers_user_id");

                    b.ToTable("offers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OfferModulesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid")
                        .HasColumnName("offer_id");

                    b.Property<int>("SiteModulesId")
                        .HasColumnType("integer")
                        .HasColumnName("site_modules_id");

                    b.HasKey("Id")
                        .HasName("pk_offer_modules");

                    b.HasIndex("OfferId")
                        .HasDatabaseName("ix_offer_modules_offer_id");

                    b.HasIndex("SiteModulesId")
                        .HasDatabaseName("ix_offer_modules_site_modules_id");

                    b.ToTable("offer_modules", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OfferOptionalDesignsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid")
                        .HasColumnName("offer_id");

                    b.Property<int>("OptionalDesignId")
                        .HasColumnType("integer")
                        .HasColumnName("optional_design_id");

                    b.HasKey("Id")
                        .HasName("pk_offer_optional_designs");

                    b.HasIndex("OfferId")
                        .HasDatabaseName("ix_offer_optional_designs_offer_id");

                    b.HasIndex("OptionalDesignId")
                        .HasDatabaseName("ix_offer_optional_designs_optional_design_id");

                    b.ToTable("offer_optional_designs", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OfferSupportEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid")
                        .HasColumnName("offer_id");

                    b.Property<int>("SiteSupportId")
                        .HasColumnType("integer")
                        .HasColumnName("site_support_id");

                    b.HasKey("Id")
                        .HasName("pk_offer_supports");

                    b.HasIndex("OfferId")
                        .HasDatabaseName("ix_offer_supports_offer_id");

                    b.HasIndex("SiteSupportId")
                        .HasDatabaseName("ix_offer_supports_site_support_id");

                    b.ToTable("offer_supports", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OptionalDesignEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasDefaultValue("")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_optional_designs");

                    b.ToTable("optional_designs", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Agreement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("agreement");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("uuid")
                        .HasColumnName("offer_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("OfferId")
                        .HasDatabaseName("ix_orders_offer_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_user_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SiteDesignEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasDefaultValue("")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_site_designs");

                    b.ToTable("site_designs", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SiteModulesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasDefaultValue("")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_site_modules");

                    b.ToTable("site_modules", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SiteSupportEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasDefaultValue("")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_site_supports");

                    b.ToTable("site_supports", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SiteTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasDefaultValue("")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_site_types");

                    b.ToTable("site_types", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasDefaultValue("Not found")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasDefaultValue("Not found")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasDefaultValue("Not found")
                        .HasColumnName("middle_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasDefaultValue("user")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("ix_users_phone");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OfferEntity", b =>
                {
                    b.HasOne("Domain.Entities.SiteDesignEntity", "SiteDesign")
                        .WithMany()
                        .HasForeignKey("SiteDesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offers_site_designs_site_design_id");

                    b.HasOne("Domain.Entities.SiteTypeEntity", "SiteType")
                        .WithMany()
                        .HasForeignKey("SiteTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offers_site_types_site_type_id");

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offers_users_user_id");

                    b.Navigation("SiteDesign");

                    b.Navigation("SiteType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.OfferModulesEntity", b =>
                {
                    b.HasOne("Domain.Entities.OfferEntity", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offer_modules_offers_offer_id");

                    b.HasOne("Domain.Entities.SiteModulesEntity", "SiteModules")
                        .WithMany()
                        .HasForeignKey("SiteModulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offer_modules_site_modules_site_modules_id");

                    b.Navigation("Offer");

                    b.Navigation("SiteModules");
                });

            modelBuilder.Entity("Domain.Entities.OfferOptionalDesignsEntity", b =>
                {
                    b.HasOne("Domain.Entities.OfferEntity", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offer_optional_designs_offers_offer_id");

                    b.HasOne("Domain.Entities.OptionalDesignEntity", "OptionalDesign")
                        .WithMany()
                        .HasForeignKey("OptionalDesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offer_optional_designs_optional_designs_optional_design_id");

                    b.Navigation("Offer");

                    b.Navigation("OptionalDesign");
                });

            modelBuilder.Entity("Domain.Entities.OfferSupportEntity", b =>
                {
                    b.HasOne("Domain.Entities.OfferEntity", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offer_supports_offers_offer_id");

                    b.HasOne("Domain.Entities.SiteSupportEntity", "SiteSupport")
                        .WithMany()
                        .HasForeignKey("SiteSupportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_offer_supports_site_supports_site_support_id");

                    b.Navigation("Offer");

                    b.Navigation("SiteSupport");
                });

            modelBuilder.Entity("Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("Domain.Entities.OfferEntity", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_offers_offer_id");

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_users_user_id");

                    b.Navigation("Offer");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
