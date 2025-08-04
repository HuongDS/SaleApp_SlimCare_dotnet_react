using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;

namespace SlimcareWeb.DataAccess.Interface
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<bool> CheckProductIdExist(int productId);
        Task<IEnumerable<Review>> GetAllByProductIdAsync(int productId);
    }
}
