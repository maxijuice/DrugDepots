using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Depots.DAL.Concrete.Repositories;
using Depots.DAL.Interface.Repositories;
using Depots.ORM.Context;
using Ninject;
using Ninject.Web.Common;

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
            kernel.Bind<DbContext>().To<DepotsContext>().InSingletonScope();
            kernel.Bind<IDepotRepository>().To<DepotRepository>().InRequestScope();
            kernel.Bind<IDrugTypeRepository>().To<DrugTypeRepository>().InRequestScope();
            kernel.Bind<IDrugUnitRepository>().To<DrugUnitRepository>().InRequestScope();
            kernel.Bind<ICountryRepository>().To<CountryRepository>().InRequestScope();
        }
    }
}