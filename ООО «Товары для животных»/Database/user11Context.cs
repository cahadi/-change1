using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ООО__Товары_для_животных_.Models;

namespace ООО__Товары_для_животных_.Database
{
    public partial class user11Context : DbContext
    {
        public user11Context()
        {
        }

        public user11Context(DbContextOptions<user11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PickupPoint> PickupPoints { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.200.35;database=user11;user=user11;password=59674");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPickupPointId).HasColumnName("OrderPickupPointID");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OrderPickupPoint)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderPickupPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PickupPoints");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber })
                    .HasName("PK__OrderPro__817A26629BD84EC7");

                entity.ToTable("OrderProduct");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Order__3F466844");

                entity.HasOne(d => d.ProductArticleNumberNavigation)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductArticleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Produ__403A8C7D");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PickupPoint>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(1000)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductArticleNumber)
                    .HasName("PK__Product__2EA7DCD5AA48ED67");

                entity.ToTable("Product");

                entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductPhoto).HasColumnType("image");

                entity.Property(e => e.ProductProviderId).HasColumnName("ProductProviderID");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Categories");

                entity.HasOne(d => d.ProductManufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Manufacturers");

                entity.HasOne(d => d.ProductProvider)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Providers");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.UserPatronymic).HasMaxLength(100);

                entity.Property(e => e.UserSurname).HasMaxLength(100);

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__UserRole__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
