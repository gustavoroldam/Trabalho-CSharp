﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trabalho.Models;

#nullable disable

namespace Trabalho.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231101190338_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trabalho.Models.Consulta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("MadicoId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteID")
                        .HasColumnType("int");

                    b.Property<int>("Qtde_Vacina")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("MadicoId");

                    b.HasIndex("MedicamentoId");

                    b.HasIndex("PacienteID");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("Trabalho.Models.Medicamento_Injetaveis", b =>
                {
                    b.Property<int>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigo"));

                    b.Property<int>("Qtde_Estoque")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("unidade")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("codigo");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("Trabalho.Models.Medico", b =>
                {
                    b.Property<int>("crm")
                        .HasColumnType("int");

                    b.Property<string>("especialidade")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("telefone")
                        .HasColumnType("int");

                    b.HasKey("crm");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Trabalho.Models.Paciente", b =>
                {
                    b.Property<int>("cpf")
                        .HasColumnType("int");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("telefone")
                        .HasColumnType("int");

                    b.HasKey("cpf");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Trabalho.Models.Consulta", b =>
                {
                    b.HasOne("Trabalho.Models.Medico", "medico")
                        .WithMany()
                        .HasForeignKey("MadicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trabalho.Models.Medicamento_Injetaveis", "Medicamento_Injetaveis")
                        .WithMany()
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trabalho.Models.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("PacienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento_Injetaveis");

                    b.Navigation("medico");

                    b.Navigation("paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
