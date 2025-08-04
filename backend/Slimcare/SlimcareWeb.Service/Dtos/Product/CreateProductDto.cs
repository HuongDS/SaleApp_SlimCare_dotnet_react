namespace SlimcareWeb.Service.Dtos.Product
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Desciption { get; set; }
        public int CategoryId { get; set; }
    }
}
