using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimcareWeb.DataAccess.Entities;

namespace SlimcareWeb.Service.Mapper
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.AddressId).IsRequired();
            builder.Property(x => x.Phone_Number).IsFixedLength().HasMaxLength(10);
        }
    }
}
