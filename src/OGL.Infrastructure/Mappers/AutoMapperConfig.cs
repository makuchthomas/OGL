using AutoMapper;
using OGL.Core.Domain;
using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDto>();
                    cfg.CreateMap<User, UserDetailDto>();
                    cfg.CreateMap<Category, CategoryDto>();
                    cfg.CreateMap<Category, CategoryDetailDto>();
                    cfg.CreateMap<Advertisement, AdvertisementDto>();
                }).CreateMapper();
    }
}
