namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext()
            : base("name=CoffeeDbContext")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAIL { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<Product_View> Product_View { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.PRODUCT)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDERDETAIL)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.ORDERDETAIL)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);
        }
    }
}
