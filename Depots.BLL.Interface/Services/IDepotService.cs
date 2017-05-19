using System.Collections.Generic;
using Depots.BLL.Interface.DTO;

namespace Depots.BLL.Interface.Services
{
    public interface IDepotService : IService<DepotDTO>
    {
        IEnumerable<DepotDTO> GetByCountry(int? countryId);
        DepotDTO GetById(int id);
    }
}
