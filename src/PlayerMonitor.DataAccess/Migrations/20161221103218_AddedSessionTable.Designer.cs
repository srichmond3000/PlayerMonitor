using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PlayerMonitor.DataAccess.Interfaces;

namespace PlayerMonitor.DataAccess.Migrations
{
    [DbContext(typeof(BaseApplicationDbContext))]
    [Migration("20161221103218_AddedSessionTable")]
    partial class AddedSessionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.PlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Forename")
                        .HasMaxLength(255);

                    b.Property<string>("Surname")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("PlayerModel");
                });

            modelBuilder.Entity("Data.Models.SessionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Duration");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Data.Models.SessionModel", b =>
                {
                    b.HasOne("Data.Models.PlayerModel", "Player")
                        .WithMany("Sessions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
