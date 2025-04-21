using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Shared;

namespace Services.MappingProfiels
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResultDTO>().
                ForMember(P => P.BrandName, X => X.MapFrom(P => P.ProductBrand.Name))
                .ForMember(P => P.TypeName, X => X.MapFrom(P => P.ProductType.Name))
                .ForMember(P => P.PictureUrl, X => X.MapFrom<PictureUrlResolver>());




            CreateMap<ProductBrand, BrandResultDTO>();
            CreateMap<ProductType, TypeResultDTO>();

        }
    }
}
