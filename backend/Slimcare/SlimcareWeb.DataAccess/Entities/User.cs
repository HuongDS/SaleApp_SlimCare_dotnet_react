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

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="username">The username<see cref="string"/></param>
        /// <param name="password">The password<see cref="string"/></param>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="role">The role<see cref="Role"/></param>
        /// <param name="deleteAt">The deleteAt<see cref="DateTime"/></param>
        public User(int id, string username, string password, string email, Role role, DateTime deleteAt)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Role = role;
            Delete_At = deleteAt;
        }
    }
}
