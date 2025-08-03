namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="Address" />
    /// </summary>
    public class Address : IDelete
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UserID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the Address_Line
        /// </summary>
        public string Address_Line { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Is_Default
        /// </summary>
        public bool Is_Default { get; set; }

        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="userID">The userID<see cref="int"/></param>
        /// <param name="address_Line">The address_Line<see cref="string"/></param>
        /// <param name="city">The city<see cref="string"/></param>
        /// <param name="is_Default">The is_Default<see cref="bool"/></param>
        /// <param name="deleteAt">The deleteAt<see cref="DateTime"/></param>
        public Address(int userID, string address_Line, string city, bool is_Default, DateTime deleteAt)
        {
            UserID = userID;
            Address_Line = address_Line;
            City = city;
            Is_Default = is_Default;
            Delete_At = deleteAt;
        }
    }
}
