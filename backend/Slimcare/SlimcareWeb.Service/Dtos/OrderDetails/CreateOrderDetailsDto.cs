namespace SlimcareWeb.Service.Dtos.OrderDetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SlimcareWeb.DataAccess.Entities;

    public class CreateOrderDetailsDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "This field can not be negative.")]
        public int Quantity { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "This field can not be negative.")]
        public double Total_Price { get; set; }
    }
}
