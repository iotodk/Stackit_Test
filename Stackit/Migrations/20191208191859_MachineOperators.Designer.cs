﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stackit.Data;

namespace Stackit.Migrations
{
    [DbContext(typeof(StackitDbContext))]
    [Migration("20191208191859_MachineOperators")]
    partial class MachineOperators
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stackit.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Stackit.Models.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "S_Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "S_Operator"
                        },
                        new
                        {
                            Id = 3,
                            Name = "K_Admin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "K_Ope"
                        });
                });

            modelBuilder.Entity("Stackit.Models.MOperator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Stackit.Models.Machine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Stackit.Models.MachineOperator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MachineId");

                    b.HasIndex("OperatorId");

                    b.ToTable("MachineOperator");
                });

            modelBuilder.Entity("Stackit.Models.Client", b =>
                {
                    b.HasOne("Stackit.Models.ClientType", "Type")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Stackit.Models.MachineOperator", b =>
                {
                    b.HasOne("Stackit.Models.Machine", "Machine")
                        .WithMany("MachineOperators")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stackit.Models.MOperator", "Operator")
                        .WithMany("MachineOperators")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}