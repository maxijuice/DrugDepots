using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.BLL.Interface.DTO;

namespace Depots.BLL.Interface.Services
{
    public interface IDrugUnitService : IService<DrugUnitDTO>, IPageable<DrugUnitDTO>
    {
        IEnumerable<DrugUnitDTO> GetByDepot(int? depotId); 
        void UpdateUnit(DrugUnitDTO unitToUpdate);
        IEnumerable<DrugUnitDTO> Purchase(int depotId, int drugTypeId, int amount);
    }
}
