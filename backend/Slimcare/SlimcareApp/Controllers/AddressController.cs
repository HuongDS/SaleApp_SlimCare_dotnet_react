using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet("/GetAddress")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAllAsync()
        {
            return Ok(await _addressService.GetAllAsync());
        }
        [HttpGet("/GetAddress/{id}")]
        public async Task<ActionResult<Address>> GetByIdAsync(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }
        [HttpPost("/AddAddress")]
        public async Task<ActionResult<AddressViewDto>> AddAsync(CreateAddressDto data)
        {
            return Ok(await _addressService.AddAddressAsync(data));
        }
        [HttpPut("/UpdateAddress")]
        public async Task<ActionResult<AddressViewDto>> UpdateAsync(UpdateAddressDto data)
        {
            try
            {
                return Ok(await _addressService.UpdateAsync(data));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("/SetAddressDefault/{id}")]
        public async Task<ActionResult<Address>> SetDefaultAsync(int id)
        {
            try
            {
                var address = await _addressService.SetAddressToDefault(id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/DeleteAddress")]
        public async Task<ActionResult<Address>> SoftDeleteAsync(int id)
        {
            try
            {
                var address = await _addressService.SoftDeleteAsync(id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}