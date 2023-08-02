using Common.Infra;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verify.Core.DAL;
using Verify.Core.Services;
using Verify.DAL;

namespace Verify.Service.Config
{
    public static class DIModule
    {
        public static IServiceCollection AddModulelDI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            serviceCollection.AddScoped(typeof(ICountryService), typeof(CountryService));
            serviceCollection.AddScoped(typeof(ICountryDAL), typeof(CountryDAL));
            return serviceCollection;
        }
    }
}
