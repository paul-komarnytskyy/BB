using BB.Core.Context.Configurations;
using BB.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Core
{
    public partial class BBEntities : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Characteristic> Characteristics { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public virtual DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

        public virtual DbSet<ProductDetails> ProductDetails { get; set; }

        public virtual DbSet<ProductPicture> ProductPictures { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<StatusUpdate> StatusUpdates { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserDetails> UserDetails { get; set; }

        public virtual DbSet<UserReaction> UserReactions { get; set; }

        public BBEntities() : base("name=DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressEntityConfiguration());
            modelBuilder.Configurations.Add(new CharacteristicEntityConfiguration());
            modelBuilder.Configurations.Add(new CommentEntityConfiguration());
            modelBuilder.Configurations.Add(new OrderEntityConfiguration());
            modelBuilder.Configurations.Add(new OrderItemEntityConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoriesEntityConfiguration());
            modelBuilder.Configurations.Add(new ProductCharacteristicEntityConfiguration());
            modelBuilder.Configurations.Add(new ProductDetailsEntityConfiguration());
            modelBuilder.Configurations.Add(new ProductEntityConfiguration());
            modelBuilder.Configurations.Add(new ProductPictureEntityConfiguration());
            modelBuilder.Configurations.Add(new RatingsEntityConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            modelBuilder.Configurations.Add(new StatusUpdateEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new UserDetailsEntityConfiguration());
            modelBuilder.Configurations.Add(new UserReactionEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
