namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Enums;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="Order" />
    /// </summary>
    public class Order : IDelete
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the Order_Date
        /// </summary>
        public DateTime Order_Date { get; set; }

        /// <summary>
        /// Gets or sets the Delivered_Date
        /// </summary>
        public DateTime Delivered_Date { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Gets or sets the Recipient_Name
        /// </summary>
        public string Recipient_Name { get; set; }

        /// <summary>
        /// Gets or sets the Payment_Method
        /// </summary>
        public string Payment_Method { get; set; }

        /// <summary>
        /// Gets or sets the Phone_Number
        /// </summary>
        public string Phone_Number { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Order_Status Status { get; set; }

        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="userId">The userId<see cref="int"/></param>
        /// <param name="addressId">The addressId<see cref="int"/></param>
        /// <param name="order_Date">The order_Date<see cref="DateTime"/></param>
        /// <param name="delivered_Date">The delivered_Date<see cref="DateTime"/></param>
        /// <param name="recipient_Name">The recipient_Name<see cref="string"/></param>
        /// <param name="payment_Method">The payment_Method<see cref="string"/></param>
        /// <param name="phone_Number">The phone_Number<see cref="string"/></param>
        /// <param name="status">The status<see cref="Order_Status"/></param>
        /// <param name="delete_At">The delete_At<see cref="DateTime"/></param>
        public Order(int id, int userId, int addressId, DateTime order_Date, DateTime delivered_Date, string recipient_Name, string payment_Method, string phone_Number, Order_Status status, DateTime delete_At)
        {
            Id = id;
            UserId = userId;
            AddressId = addressId;
            Order_Date = order_Date;
            Delivered_Date = delivered_Date;
            Recipient_Name = recipient_Name;
            Payment_Method = payment_Method;
            Phone_Number = phone_Number;
            Status = status;
            Delete_At = delete_At;
        }
    }
}
