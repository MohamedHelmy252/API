using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager _serviceManager) : ControllerBase
    {

        #region Get All Product 
        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductResultDTO>>> GetAllProducts()
        {
            var Products = await _serviceManager.ProductService.GetAllProductAsync();
            return Ok(Products);
        }





        #endregion
        #region Get All Prodct Brand 
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllBrands()
        {
            var Brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }
        #endregion
        #region Get All Product Type
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDTO>>> GetAllTyeps()
        { 
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(Types);

        }



        #endregion


        #region Get Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDTO>> GetById(int id)
        { 
        var Product = await _serviceManager.ProductService.GetByIdAsync(id);
            if (Product == null)
                return NotFound();
            return Ok(Product);
        }
        #endregion





    }


}
