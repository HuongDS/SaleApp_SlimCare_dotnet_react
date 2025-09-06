namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="Product" />
    /// </summary>
    public class Product : IEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the Stock
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the Desciption
        /// </summary>
        public string Desciption { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Category
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the OrderDetails
        /// </summary>
        public List<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get; set; }

        public string Img { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="price">The price<see cref="double"/></param>
        /// <param name="stock">The stock<see cref="int"/></param>
        /// <param name="desciption">The desciption<see cref="string"/></param>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="category">The category<see cref="Category"/></param>
        /// <param name="orderDetails">The orderDetails<see cref="List{OrderDetails}"/></param>
        /// <param name="delete_At">The delete_At<see cref="DateTime"/></param>
        public Product(int id, string name, double price, int stock, string desciption, int categoryId, Category category, List<OrderDetails> orderDetails, DateTime delete_At, string img)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Desciption = desciption;
            CategoryId = categoryId;
            Category = category;
            OrderDetails = orderDetails;
            Delete_At = delete_At;
            Img = img;
        }
    }
}
