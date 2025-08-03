namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
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

        public int OrderId { get; set; }
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public int ProductId { get; set; }
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
