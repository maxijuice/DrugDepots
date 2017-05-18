using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.UnitOfWork;

namespace Depots.BLL.Concrete.Services
{
    public abstract class CommonService
    {
        protected IMapper mapper;
        protected IDepotsUnitOfWork unitOfWork;

        protected CommonService(IDepotsUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = uow;
        } 
    }
}
