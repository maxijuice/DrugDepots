using System.Collections.Generic;
using Depots.BLL.Interface.DTO;

namespace Depots.BLL.Interface.Services
{
    public interface IDepotService
    {
        IEnumerable<DepotDTO> GetAllDepots();
    }
}
