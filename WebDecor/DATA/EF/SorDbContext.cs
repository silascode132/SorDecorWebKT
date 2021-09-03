using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDecor.DATA.EF
{
    public partial class SorDbContext : DbContext
    {
        public SorDbContext()
            : base("name=SorDbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<ItemInCart> ItemInCarts { get; set; }
        public virtual DbSet<Made> Mades { get; set; }
        public virtual DbSet<OrderBill> OrderBills { get; set; }
        public virtual DbSet<OrderInfo> OrderInfoes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RoleAdmin> RoleAdmins { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .HasMany(e => e.ItemInCarts)
                .WithRequired(e => e.Cart)
                .HasForeignKey(e => e.CartItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ItemInCart>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ItemInCart>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<ItemInCart>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ItemInCart>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ItemInCart>()
                .Property(e => e.CartItemID)
                .IsUnicode(false);

            modelBuilder.Entity<Made>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Made1)
                .HasForeignKey(e => e.Made)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderBill>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBill>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBill>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBill>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<OrderBill>()
                .HasMany(e => e.OrderInfoes)
                .WithRequired(e => e.OrderBill)
                .HasForeignKey(e => e.ItemOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderInfo>()
                .Property(e => e.ItemOrder)
                .IsUnicode(false);

            modelBuilder.Entity<OrderInfo>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderInfo>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Sale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ItemInCarts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderInfoes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleAdmin>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.RoleAdmin1)
                .HasForeignKey(e => e.RoleAdmin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.UserAccount)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.UserAccount)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .HasMany(e => e.OrderBills)
                .WithRequired(e => e.UserAccount)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
