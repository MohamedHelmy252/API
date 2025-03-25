using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //Relations
        #region Product Brand
        public ProductBrand ProductBrand { get; set; }
        public int BrandedId { get; set; }
        #endregion
        #region ProductTupe
        public ProductType ProductType { get; set; }
        public int ProductId { get; set; }

        #endregion
    }
}
