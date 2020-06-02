using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPhone.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace WebPhone.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phones.Entities.Shop", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("datetime2");

                b.Property<string>("City")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Street")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("House")
                    .HasColumnType("int");

                b.Property<DateTime?>("ModifiedAt")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("Shops");
            });

            modelBuilder.Entity("Phones.Entities.Phone", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ShopId")
                    .HasColumnType("int");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("datetime2");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime?>("ModifiedAt")
                    .HasColumnType("datetime2");

                b.Property<string>("ShorDesc")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LongDesc")
                    .HasColumnType("nvarchar(max)");

                b.Property<ushort>("Price")
                    .HasColumnType("ushort");

                b.HasKey("Id");

                b.HasIndex("ShopId");

                b.ToTable("Phones");
            });

            modelBuilder.Entity("Phones.Entities.Phone", b =>
            {
                b.HasOne("Phones.Entities.Shop", "Shop")
                    .WithMany("Phones")
                    .HasForeignKey("ShopId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
