using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;

namespace SlimcareWeb.DataAccess.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> CheckProductExist(string productName);
        Task<IEnumerable<Product>> GetProductsWithQuantity(int quantity);
    }
}
