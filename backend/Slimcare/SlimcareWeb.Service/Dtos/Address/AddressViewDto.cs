using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimcareWeb.Service.Dtos
{
    public class AddressViewDto
    {
        public string Address_Line { get; set; }
        public string City { get; set; }
        public bool Is_Default { get; set; } = false;
    }
}
