using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depots.BLL.Interface.Services
{
    public interface IPageable<T>
    {
        IEnumerable<T> GetPage(int pageNumber, int pageSize);
        int Count { get; }
    }
}
