using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IAddressService
    {
        Task<AddressViewDto> AddAddressAsync(CreateAddressDto data);
        Task<Address> SoftDeleteAsync(int id);
        Task<Address?> GetByIdAsync(int id);
        Task<IEnumerable<Address>> GetAllAsync();
        Task<AddressViewDto> UpdateAsync(UpdateAddressDto data);
    }
}
