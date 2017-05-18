using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Depots.BLL.Interface.Mapper;

namespace Depots.WebUI.Infrastructure
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServicesProfile());
            });

            return config;
        }
    }
}