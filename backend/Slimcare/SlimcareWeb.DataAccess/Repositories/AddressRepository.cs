namespace SlimcareWeb.DataAccess.Repositories
{
    using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateAllAddressToNotDefaultAsync(int userId)
        {
            var addresses = await _dbContext.Addresses.Where(a => a.UserID == userId && a.Is_Default).ToListAsync();
            foreach (var address in addresses)
            {
                address.Is_Default = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
