using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presestance.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            #region Product 
            builder.Property(P => P.Price).
                HasColumnType("decimal(18,3)");
            #endregion


            #region Product  Relation With ProductBrand
            builder.HasOne(P=>P.ProductBrand).
                WithMany().HasForeignKey(P => P.BrandId);
            #endregion



            #region Product  Relation With ProductType
            builder.HasOne(P => P.ProductType).
                WithMany().HasForeignKey(P => P.TypeId);
            #endregion

        }
    }
}
