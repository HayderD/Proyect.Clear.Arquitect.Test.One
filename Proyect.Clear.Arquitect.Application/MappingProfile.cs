using AutoMapper;
using Proyect.Clear.Arquitect.Application.Requests;
using Proyect.Clear.Arquitect.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Proyect.Clear.Arquitect.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>()
     .ForMember(dest => dest.DateCreate,
         opt => opt.MapFrom(src =>
             src.DateCreate.ToString("dd/MM/yyyy HH:mm:ss")));
        }
    }

}
