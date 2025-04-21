using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entity;
using Shared;

namespace Services
{
    public class ProductService(IUnitOfWork unitOfWork , IMapper mapper) : IProductService
    {
    

        public async Task<IEnumerable<ProductResultDTO>> GetAllProductAsync()
        {
            var Products = await unitOfWork.GetGenericRepository<Product, int>().GetAllAsync();
            var result = mapper.Map<IEnumerable<ProductResultDTO>>(Products);
            return result;
        }

        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
              var Types = await unitOfWork.GetGenericRepository<ProductType, int>().GetAllAsync();
              var result = mapper.Map<IEnumerable<TypeResultDTO>>(Types);
              return result;
        }
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            var Brands = await unitOfWork.GetGenericRepository<ProductBrand, int>().GetAllAsync();
            var result = mapper.Map<IEnumerable<BrandResultDTO>>(Brands);
            return result;

        }
        public async Task<ProductResultDTO?> GetByIdAsync(int id)
        {
            var Product =await unitOfWork.GetGenericRepository<Product, int>().GetByIdAsync(id);
            var result = mapper.Map<ProductResultDTO>(Product);
            return result;
        }
    }
}
