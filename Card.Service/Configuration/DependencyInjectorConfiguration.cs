using Card.Cross.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Service.Configuration
{
    public static class DependencyInjectorConfiguration
    {
        public static void RegisterDependencyInjector(this IServiceCollection services)
        {
            DepedencyInjectRegistration.Register(services);
        }

    }
}
