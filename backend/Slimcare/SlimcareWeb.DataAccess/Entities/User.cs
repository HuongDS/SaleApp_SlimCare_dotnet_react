namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Enums;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public class User : IEntity, IDelete
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get; set; }

        public string Salting { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        public User(int id, string username, string password, string email, Role role, DateTime delete_At, string salting)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Role = role;
            Delete_At = delete_At;
            Salting = salting;
        }

    }
}
