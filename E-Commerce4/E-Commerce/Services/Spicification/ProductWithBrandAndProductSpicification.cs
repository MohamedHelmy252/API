using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entity;
using Shared;

namespace Services.Spicification
{
    internal class ProductWithBrandAndProductSpicification : Spicification<Product>
    {

        //Get By ID
        public ProductWithBrandAndProductSpicification(int id)
            : base(Product=>Product.Id == id)//Get Id From DB
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }

        //Get All 
        public ProductWithBrandAndProductSpicification(ProductSpecificationParameters parameters)
            : base(product =>
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);

            #region Sort

            #endregion

        }
    }
}
