using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyWebApp.Models;

namespace MyWebApp.Migrations
{
    [DbContext(typeof(SpeakerDbContext))]
    [Migration("20160706033035_Initial migration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApp.Models.Speaker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Topic");

                    b.HasKey("ID");

                    b.ToTable("Speakers");
                });
        }
    }
}
