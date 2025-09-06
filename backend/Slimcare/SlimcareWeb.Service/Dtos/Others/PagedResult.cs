using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.Dtos.Others
{
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> items { get; set; } = Enumerable.Empty<T>();
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int totalPages => (int)Math.Ceiling((double)totalCount / pageSize);
    }
}
