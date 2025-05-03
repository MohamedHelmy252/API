using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using AutoMapper;
using Shared;
using Microsoft.Extensions.Configuration;
namespace Services.MappingProfiels
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductResultDTO, string>
    {
        public string Resolve(Product source, ProductResultDTO destination, string destMember, ResolutionContext context)
        {
           if(string.IsNullOrEmpty(source.PictureUrl) ) return string.Empty;

            return $"{configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
