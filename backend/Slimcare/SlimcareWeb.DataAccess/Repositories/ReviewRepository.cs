using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;

namespace SlimcareWeb.DataAccess.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
