﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelLayer;

namespace QuantityMeasurement.Migrations
{
    [DbContext(typeof(QuantityMeasurementDBContext))]
    [Migration("20201019124239_SubUnit-Validations")]
    partial class SubUnitValidations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelLayer.MainUnits", b =>
                {
                    b.Property<int>("MainUnitsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MainUnitName")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(50);

                    b.HasKey("MainUnitsId");

                    b.ToTable("MainUnits");
                });

            modelBuilder.Entity("ModelLayer.Subunit", b =>
                {
                    b.Property<int>("SubunitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("SubUnitsValue")
                        .HasColumnType("real");

                    b.Property<string>("SubunitName")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(50);

                    b.HasKey("SubunitId");

                    b.ToTable("Subunits");
                });
#pragma warning restore 612, 618
        }
    }
}
