﻿// <auto-generated />
using System;
using BlogNet.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogNet.Data.Migrations
{
    [DbContext(typeof(AppBlogContext))]
    [Migration("20230404131930_TabelaCurtidas")]
    partial class TabelaCurtidas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogNet.Domain.Models.CurtidaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Curtidas", (string)null);
                });

            modelBuilder.Entity("BlogNet.Domain.Models.PostModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("BlogNet.Domain.Models.CurtidaModel", b =>
                {
                    b.HasOne("BlogNet.Domain.Models.PostModel", "PostModel")
                        .WithMany("Curtidas")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostModel");
                });

            modelBuilder.Entity("BlogNet.Domain.Models.PostModel", b =>
                {
                    b.Navigation("Curtidas");
                });
#pragma warning restore 612, 618
        }
    }
}
