﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TSS.Data;

#nullable disable

namespace TSS.Migrations
{
    [DbContext(typeof(TSSContext))]
    [Migration("20240723144509_seed-TipoPlano")]
    partial class seedTipoPlano
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TSS.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("Tipocontato_Id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Tipocontato_Id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("TSS.Models.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("Tipoplano_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Tipoplano_Id");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("TSS.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Dtfim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dtini")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status_Id")
                        .HasColumnType("int");

                    b.Property<int>("Tiposervico_Id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Status_Id");

                    b.HasIndex("Tiposervico_Id");

                    b.HasIndex("Usuario_Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("TSS.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TSS.Models.Tipocontato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tipocontato");
                });

            modelBuilder.Entity("TSS.Models.Tipoplano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tipoplano");
                });

            modelBuilder.Entity("TSS.Models.Tiposervico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tiposervico");
                });

            modelBuilder.Entity("TSS.Models.Tipousuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tipousuario");
                });

            modelBuilder.Entity("TSS.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF_CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime>("Dtnasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Plano_Id")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Tipousuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Plano_Id");

                    b.HasIndex("Tipousuario_Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TSS.Models.Contato", b =>
                {
                    b.HasOne("TSS.Models.Tipocontato", "Tipocontato")
                        .WithMany()
                        .HasForeignKey("Tipocontato_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TSS.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipocontato");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TSS.Models.Plano", b =>
                {
                    b.HasOne("TSS.Models.Tipoplano", "Tipoplano")
                        .WithMany()
                        .HasForeignKey("Tipoplano_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipoplano");
                });

            modelBuilder.Entity("TSS.Models.Servico", b =>
                {
                    b.HasOne("TSS.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("Status_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TSS.Models.Tiposervico", "Tiposervico")
                        .WithMany()
                        .HasForeignKey("Tiposervico_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TSS.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Tiposervico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TSS.Models.Usuario", b =>
                {
                    b.HasOne("TSS.Models.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("Plano_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TSS.Models.Tipousuario", "Tipousuario")
                        .WithMany()
                        .HasForeignKey("Tipousuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plano");

                    b.Navigation("Tipousuario");
                });
#pragma warning restore 612, 618
        }
    }
}
