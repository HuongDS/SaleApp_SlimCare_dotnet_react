namespace SlimcareWeb.DataAccess.Repositories
{
    using SlimcareWeb.DataAccess.Entities;
    using SlimcareWeb.DataAccess.Interface;

    /*
     Ở class này không cần kế thừa IAddressRepository vì nó đã kế thừa GenericRepository<Address> và không có thêm method nào đặc thù ngoài các
        method đã có trong GenericRepository.     */

    /// <summary>
    /// Defines the <see cref="AddressRepository" />
    /// </summary>
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="SlimCareDbContext"/></param>
        public AddressRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
