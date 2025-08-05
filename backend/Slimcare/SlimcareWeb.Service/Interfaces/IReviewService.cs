using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Review;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewViewDto> AddAsync(CreateReviewDto data);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
        Task<Review> SoftDeleteAsync(int id);
        Task<ReviewViewDto> UpdateAsync(ReviewUpdateDto data);
    }
}
