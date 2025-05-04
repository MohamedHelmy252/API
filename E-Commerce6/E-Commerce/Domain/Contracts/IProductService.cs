using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Domain.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductResultDTO>> GetAllProductAsync(ProductSpecificationParameters parameters);
        public Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        public Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync();
        public Task<ProductResultDTO?> GetByIdAsync(int id);
    }
}
