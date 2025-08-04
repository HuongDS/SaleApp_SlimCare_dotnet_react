namespace SlimcareWeb.Service.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SlimcareWeb.DataAccess.Entities;

    public class CreateAddressDto
    {
        public int UserID { get; set; }
        public string Address_Line { get; set; }
        public string City { get; set; }
        public bool Is_Default { get; set; } = false;
    }
}
