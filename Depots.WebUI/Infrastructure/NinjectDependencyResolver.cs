using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Depots.BLL.Interface.Services;
using Depots.DAL.Concrete.Repositories;
using Depots.DAL.Interface.Repositories;
using Depots.ORM.Context;
using Ninject;
using Ninject.Web.Common;
using Depots.BLL.Concrete.Services;
using Depots.DAL.Concrete.UnitOfWork;
using Depots.DAL.Interface.UnitOfWork;

namespace Depots.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            kernel.Bind<IMapper>().ToConstant(mapper);

            kernel.Bind<DbContext>().To<DepotsContext>().InRequestScope();
            kernel.Bind<IDepotRepository>().To<DepotRepository>().InRequestScope();
            kernel.Bind<IDrugTypeRepository>().To<DrugTypeRepository>().InRequestScope();
            kernel.Bind<IDrugUnitRepository>().To<DrugUnitRepository>().InRequestScope();
            kernel.Bind<ICountryRepository>().To<CountryRepository>().InRequestScope();
            kernel.Bind<IDepotsUnitOfWork>().To<DepotsUnitOfWork>().InRequestScope();
            kernel.Bind<IDepotService>().To<DepotService>().InRequestScope();
            kernel.Bind<IDrugUnitService>().To<DrugUnitService>().InRequestScope();
        }
    }
}