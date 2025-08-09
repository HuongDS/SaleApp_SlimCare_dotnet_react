using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Enums;

namespace SlimcareWeb.Service.Dtos.Order
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime Order_Date { get; set; } = DateTime.Now;
        public DateTime Delivered_Date { get; set; }
        public string Recipient_Name { get; set; }
        public string Payment_Method { get; set; }
        [Phone]
        public string Phone_Number { get; set; }
        public Order_Status Status { get; set; } = Order_Status.PENDING;
    }
}
