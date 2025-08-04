using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            this._addressRepository = addressRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _addressRepository.GetAllAsync();
        }
        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }
        public async Task<AddressViewDto> AddAddressAsync(CreateAddressDto data)
        {
            var address = _mapper.Map<Address>(data);
            await _addressRepository.AddAsync(address);
            return _mapper.Map<AddressViewDto>(address);
        }
        public async Task<AddressViewDto> UpdateAsync(UpdateAddressDto data)
        {
            var address = await _addressRepository.GetByIdAsync(data.Id);
            if (address == null)
            {
                throw new Exception("Not Found Address with Id: " + data.Id);
            }
            address = _mapper.Map<Address>(data);
            await _addressRepository.UpdateAsync(address);
            return _mapper.Map<AddressViewDto>(address);
        }
        public async Task<Address> SoftDeleteAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null)
            {
                throw new Exception("Not Found Address with Id: " + id);
            }
            await _addressRepository.SoftDeleteAsync(id);
            return address;
        }
    }
}
