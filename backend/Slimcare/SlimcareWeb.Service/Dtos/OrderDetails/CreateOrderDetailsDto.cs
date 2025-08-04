namespace SlimcareWeb.Service.Dtos.OrderDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SlimcareWeb.DataAccess.Entities;

    public class CreateOrderDetailsDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Total_Price { get; set; }
    }
}
