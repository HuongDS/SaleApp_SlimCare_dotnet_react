namespace SlimcareWeb.DataAccess.Entities
{
    using System;
    using SlimcareWeb.DataAccess.Interface;

    /// <summary>
    /// Defines the <see cref="Category" />
    /// </summary>
    public class Category : IDelete, IEntity
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Delete_At
        /// </summary>
        public DateTime Delete_At { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="iD">The iD<see cref="int"/></param>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="description">The description<see cref="string"/></param>
        /// <param name="deleteAt">The deleteAt<see cref="DateTime"/></param>
        public Category(int iD, string name, string description, DateTime deleteAt)
        {
            Id = iD;
            Name = name;
            Description = description;
            Delete_At = deleteAt;
        }
    }
}
