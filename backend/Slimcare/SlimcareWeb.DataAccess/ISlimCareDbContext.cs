namespace SlimcareWeb.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using SlimcareWeb.DataAccess.Entities;

    /// <summary>
    /// Defines the <see cref="ISlimCareDbContext" />
    /// </summary>
    public interface ISlimCareDbContext
    {
        /// <summary>
        /// Gets or sets the Addresses
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the Categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the Orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the OrderDetails
        /// </summary>
        public DbSet<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Reviews
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
