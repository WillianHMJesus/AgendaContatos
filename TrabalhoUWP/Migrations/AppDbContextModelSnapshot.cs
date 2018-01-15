using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrabalhoUWP.Repository;

namespace TrabalhoUWP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("TrabalhoUWP.Model.Contato", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<bool?>("Favorito");

                    b.Property<string>("Nome");

                    b.Property<byte[]>("Picture");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });
        }
    }
}
