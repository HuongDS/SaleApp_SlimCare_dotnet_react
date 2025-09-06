using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.Dtos.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "This field can not be negative.")]
        public double Price { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "This field can not be negative.")]
        public int Stock { get; set; }
        public string Desciption { get; set; }
        public int CategoryId { get; set; }
        public string Img { get; set; }
    }
}
