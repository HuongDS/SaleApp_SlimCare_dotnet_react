namespace SlimcareWeb.DataAccess.Entities
{
    using System;

    /// <summary>
    /// Defines the <see cref="Review" />
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the Rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the Review_At
        /// </summary>
        public DateTime Review_At { get; set; } = DateTime.Now;

        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        public Review()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="userId">The userId<see cref="int"/></param>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <param name="rating">The rating<see cref="int"/></param>
        /// <param name="comment">The comment<see cref="string"/></param>
        /// <param name="review_At">The review_At<see cref="DateTime"/></param>
        public Review(int id, int userId, int productId, int rating, string comment, DateTime review_At)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Rating = rating;
            Comment = comment;
            Review_At = review_At;
        }
    }
}
