using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CoralCivet_Technology_Ecommerce_Website.Models.CoralCivet
{
    public partial class CoralCivetContext : DbContext
    {
        public CoralCivetContext()
            : base("name=CoralCivetContext")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<ordersdetail> ordersdetails { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImg> ProductImgs { get; set; }
        public virtual DbSet<slider> sliders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<topic> topics { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<TypeDetail> TypeDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .HasMany(e => e.menu1)
                .WithRequired(e => e.menu2)
                .HasForeignKey(e => e.parentId);

            modelBuilder.Entity<order>()
                .HasMany(e => e.ordersdetails)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<post>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ordersdetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductImg>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.metakey)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.posts)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topId);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Type1)
                .HasForeignKey(e => e.type);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Type1)
                .WithOptional(e => e.Type2)
                .HasForeignKey(e => e.parentId);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.TypeDetails)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}
