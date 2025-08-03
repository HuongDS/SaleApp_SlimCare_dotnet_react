namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="Product" />
    /// </summary>
    public class Product : IDelete
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
        /// Gets or sets the Desciption
        /// </summary>
        public string Desciption { get; set; }

        /// <summary>
        /// Gets or sets the Category_Id
        /// </summary>
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get; set; }

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
        /// <param name="desciption">The desciption<see cref="string"/></param>
        /// <param name="category_Id">The category_Id<see cref="int"/></param>
        /// <param name="delete_At">The delete_At<see cref="DateTime"/></param>
        public Product(int id, string name, double price, string desciption, int category_Id, DateTime delete_At)
        {
            Id = id;
            Name = name;
            Price = price;
            Desciption = desciption;
            CategoryId = category_Id;
            Delete_At = delete_At;
        }
    }
}
