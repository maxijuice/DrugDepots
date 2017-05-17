using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugUnitDTO = Depots.BLL.Interface.DTO.DrugUnitDTO;

namespace Depots.BLL.Interface.Services
{
    public interface IDrugUnitService
    {
        IEnumerable<DrugUnitDTO> GetAllDrugUnits();
    }
}
