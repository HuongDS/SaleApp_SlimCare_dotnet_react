namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="OrderDetails" />
    /// </summary>
    public class OrderDetails : IDelete
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the Order
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Total_Price
        /// </summary>
        public double Total_Price { get; set; }

        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetails"/> class.
        /// </summary>
        public OrderDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetails"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="orderId">The orderId<see cref="int"/></param>
        /// <param name="order">The order<see cref="Order"/></param>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <param name="quantity">The quantity<see cref="int"/></param>
        /// <param name="total_Price">The total_Price<see cref="double"/></param>
        /// <param name="delete_At">The delete_At<see cref="DateTime"/></param>
        public OrderDetails(int id, int orderId, Order order, int productId, Product product, int quantity, double total_Price, DateTime delete_At)
        {
            Id = id;
            OrderId = orderId;
            Order = order;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Total_Price = total_Price;
            Delete_At = delete_At;
        }
    }
}
