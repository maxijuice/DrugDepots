using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.BLL.Interface.DTO;

namespace Depots.BLL.Interface.Services
{
    public interface IDrugUnitService
    {
        IEnumerable<DrugUnitDTO> GetAllDrugUnits();
        int CountUnits { get; }
        IEnumerable<DrugUnitDTO> GetPage(int pageNumber, int pageSize);
    }
}
