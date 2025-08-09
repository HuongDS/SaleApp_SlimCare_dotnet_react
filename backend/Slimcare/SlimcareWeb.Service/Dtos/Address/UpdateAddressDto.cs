namespace SlimcareWeb.Service.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SlimcareWeb.DataAccess.Entities;

    public class UpdateAddressDto
    {
        public int Id { get; set; }
        [Required]
        public string Address_Line { get; set; }
        [Required]
        public string City { get; set; }
        public bool Is_Default { get; set; }
    }
}
