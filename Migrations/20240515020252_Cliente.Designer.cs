﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_bank.Data;

namespace api_bank.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240515020252_Cliente")]
    partial class Cliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AtivoCliente", b =>
                {
                    b.Property<int>("AtivosAtivoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("clientesClienteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AtivosAtivoId", "clientesClienteId");

                    b.HasIndex("clientesClienteId");

                    b.ToTable("AtivoCliente");
                });

            modelBuilder.Entity("api_bank.Models.Ativo", b =>
                {
                    b.Property<int>("AtivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AtivoName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("AtivoId");

                    b.ToTable("Ativos");
                });

            modelBuilder.Entity("api_bank.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("api_bank.Models.ClienteAtivo", b =>
                {
                    b.Property<int>("ClienteAtivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AtivoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClienteAtivoId");

                    b.HasIndex("AtivoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClienteAtivos");
                });

            modelBuilder.Entity("AtivoCliente", b =>
                {
                    b.HasOne("api_bank.Models.Ativo", null)
                        .WithMany()
                        .HasForeignKey("AtivosAtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_bank.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("clientesClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_bank.Models.ClienteAtivo", b =>
                {
                    b.HasOne("api_bank.Models.Ativo", "Ativo")
                        .WithMany()
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_bank.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ativo");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
