using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos.Product;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Product>> GetProductsWithQuantityAsync(int quantity)
        {
            return await _productRepository.GetProductsWithQuantity(quantity);
        }
        public async Task<ProductViewDto> AddAsync(CreateProductDto data)
        {
            var checkNameProduct = await _productRepository.CheckProductExist(data.Name);
            if (checkNameProduct)
            {
                throw new Exception("Product already exists");
            }
            if (data.Stock < 0 || data.Price < 0)
            {
                throw new Exception("Stock and Price must be greater than or equal to 0.");
            }
            var product = _mapper.Map<Product>(data);
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductViewDto>(product);
        }
        public async Task<ProductViewDto> UpdateAsync(UpdateProductDto data)
        {
            var checkIdProduct = await _productRepository.GetByIdAsync(data.Id);
            if (checkIdProduct == null)
            {
                throw new Exception("Not Found Product with Id: " + data.Id);
            }
            if (data.Stock < 0 || data.Price < 0)
            {
                throw new Exception("Stock and Price must be greater than or equal to 0.");
            }
            var product = _mapper.Map<Product>(data);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductViewDto>(product);
        }
        public async Task<Product> SoftDeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Not Found Product with Id: " + id);
            }
            await _productRepository.SoftDeleteAsync(id);
            return product;
        }
    }
}
