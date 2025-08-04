using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos.Category;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Category>>(categories);
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<Category>(category);
        }
        public async Task<CategoryViewDto> AddAsync(CreateCategoryDto data)
        {
            var checkNameCategory = await _categoryRepository.CheckCategoryExist(data.Name);
            if (checkNameCategory)
            {
                throw new Exception("Category already exists");
            }
            var category = _mapper.Map<Category>(data);
            await _categoryRepository.AddAsync(category);
            return _mapper.Map<CategoryViewDto>(category);
        }
        public async Task<CategoryViewDto> UpdateAsync(UpdateCategoryDto data)
        {
            var checkIdCategory = _categoryRepository.GetByIdAsync(data.Id);
            if (checkIdCategory == null)
            {
                throw new Exception("Not Found Category with Id: " + data.Id);
            }
            var category = _mapper.Map<Category>(data);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryViewDto>(category);
        }
        public async Task<Category> SoftDeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("Not Found Category with Id: " + id);
            }
            await _categoryRepository.SoftDeleteAsync(id);
            return category;
        }
    }
}
