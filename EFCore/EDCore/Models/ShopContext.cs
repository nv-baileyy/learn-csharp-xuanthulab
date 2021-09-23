using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EFCore.Models
{
    // respresent a databse
    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(
            (ILoggingBuilder builder) =>
            {
                builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
                //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
                builder.AddConsole();
            }
        );
        // DbSet - represent a table 
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
         public DbSet<CategoryDetail> categoriesDetail { get; set; }
        private string connectionString = "Data Source=DESKTOP-TMG5088;Initial Catalog=ShopData;Integrated Security=True";
        // Onconfifuring will call when DbContext called
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            Console.WriteLine("Onconfiguring");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("OnModelCreating");
            base.OnModelCreating(modelBuilder);
            // Fluent API
            // var entiry = modelBuilder.Entity(typeof(Product));
            // // entity => Fluent Api
            //var entity = modelBuilder.Entity<Product>();
            modelBuilder.Entity<Product>(
                entity =>
                {
                    // Table Mapping
                    entity.ToTable("Sanpham");
                    // Pk
                    entity.HasKey(p => p.ProductID);
                    // Index -- enhand process
                    entity.HasIndex(p => p.Price).HasDatabaseName("index-sanphan-price");
                    // relative: category 1 - Product N
                    entity.HasOne(p => p.category)
                        .WithMany(c => c.products) // collect Navigation
                        .HasForeignKey(p => p.CategID)  // dat ten Fk
                        .OnDelete(DeleteBehavior.Cascade)       
                        .HasConstraintName("khoangoai_sanpham_category")             
                        ;
                        entity.Property(p => p.Name)
                                .HasColumnName("title")
                                .HasColumnType("nvarchar")
                                .HasMaxLength(60)
                                .IsRequired(true)
                                .HasDefaultValue("Ten san pham mac dinh")
                                ;
                }
            );
            // 1 - 1
            modelBuilder.Entity<CategoryDetail>(
                entity => {
                    entity.HasOne(d => d.category)
                    .WithOne(c => c.categoryDetail)
                    .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId)
                    .OnDelete(DeleteBehavior.Cascade)
                    ;
                }
            );

        }


    }
}