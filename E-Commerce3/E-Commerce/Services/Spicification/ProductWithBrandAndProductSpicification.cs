using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entity;

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
        public ProductWithBrandAndProductSpicification()
            : base(null)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
    }
}
