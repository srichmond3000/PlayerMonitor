using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PlayerMonitor.DataAccess;

namespace PlayerMonitor.DataAccess.Migrations
{
    [DbContext(typeof(PlayerMonitorDbContext))]
    [Migration("20161217094351_SetMaxLengthForPlayerTable")]
    partial class SetMaxLengthForPlayerTable
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
        }
    }
}
