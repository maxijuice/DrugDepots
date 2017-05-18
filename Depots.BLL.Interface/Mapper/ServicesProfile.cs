using AutoMapper;
using Depots.BLL.Interface.DTO;
using Depots.ORM.Entities;

namespace Depots.BLL.Interface.Mapper
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<DrugType, DrugTypeDTO>();
            CreateMap<DrugUnit, DrugUnitDTO>();
            CreateMap<Depot, DepotDTO>();

            CreateMap<DepotDTO, Depot>();
            CreateMap<CountryDTO, Country>();
            CreateMap<DrugUnitDTO, DrugUnit>();
            CreateMap<DrugTypeDTO, DrugType>();
        }
    }
}
