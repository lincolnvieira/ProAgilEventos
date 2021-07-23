﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.Repository;

namespace ProAgil.Repository.Migrations
{
    [DbContext(typeof(ProAgilContext))]
    [Migration("20210723005628_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ProAgil.Domain.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("Email");

                    b.Property<string>("ImagemUrl");

                    b.Property<string>("Local");

                    b.Property<int>("QtdPessoas");

                    b.Property<string>("Telefone");

                    b.Property<string>("Tema");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProAgil.Domain.Lote", b =>
                {
                    b.Property<int>("LoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataFim");

                    b.Property<DateTime?>("DataInicio");

                    b.Property<int>("EventoId");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("LoteId");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProAgil.Domain.Palestrante", b =>
                {
                    b.Property<int>("PalestranteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("ImagemUrl");

                    b.Property<string>("MiniCurriculo");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("PalestranteId");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProAgil.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId");

                    b.Property<int>("PalestranteId");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestranteEventos");
                });

            modelBuilder.Entity("ProAgil.Domain.RedeSocial", b =>
                {
                    b.Property<int>("RedeSocialId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventoId");

                    b.Property<string>("Nome");

                    b.Property<int?>("PalestanteId");

                    b.Property<string>("Url");

                    b.HasKey("RedeSocialId");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestanteId");

                    b.ToTable("RedeSocials");
                });

            modelBuilder.Entity("ProAgil.Domain.Lote", b =>
                {
                    b.HasOne("ProAgil.Domain.Evento", "Evento")
                        .WithMany("Lote")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProAgil.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProAgil.Domain.Evento", "Evento")
                        .WithMany("PalestranteEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProAgil.Domain.Palestrante", "Palestrante")
                        .WithMany("PalestranteEventos")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProAgil.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProAgil.Domain.Evento", "Evento")
                        .WithMany("RedeSociais")
                        .HasForeignKey("EventoId");

                    b.HasOne("ProAgil.Domain.Palestrante", "Palestante")
                        .WithMany("RedeSociais")
                        .HasForeignKey("PalestanteId");
                });
#pragma warning restore 612, 618
        }
    }
}
