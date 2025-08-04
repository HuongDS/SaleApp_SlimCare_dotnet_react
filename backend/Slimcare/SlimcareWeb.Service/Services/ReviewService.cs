using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos.Review;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            this._reviewRepository = reviewRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _reviewRepository.GetAllAsync();
        }
        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
        {
            return await _reviewRepository.GetAllByProductIdAsync(productId);
        }
        public async Task<ReviewViewDto> AddAsync(CreateReviewDto data)
        {
            var checkProductId = await _reviewRepository.CheckProductIdExist(data.ProductId);
            if (!checkProductId)
            {
                throw new Exception("ProductId not exist.");
            }
            if (data.Rating < 1 || data.Rating > 5)
            {
                throw new Exception("Rating must be between 1 and 5.");
            }
            var review = _mapper.Map<Review>(data);
            await _reviewRepository.AddAsync(review);
            return _mapper.Map<ReviewViewDto>(review);
        }
        public async Task<ReviewViewDto> UpdateAsync(ReviewUpdateDto data)
        {
            var checkId = await _reviewRepository.GetByIdAsync(data.Id);
            if (checkId == null)
            {
                throw new Exception("Not Found Review with Id: " + data.Id);
            }
            var review = _mapper.Map<Review>(data);
            await _reviewRepository.UpdateAsync(review);
            return _mapper.Map<ReviewViewDto>(review);
        }
        public async Task<Review> SoftDeleteAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                throw new Exception("Not Found Review with Id: " + id);
            }
            await _reviewRepository.SoftDeleteAsync(id);
            return review;
        }
    }
}
