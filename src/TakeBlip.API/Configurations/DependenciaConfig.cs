using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TakeBlip.API.Interfaces;
using TakeBlip.API.Services;

namespace TakeBlip.API.Configurations
{
    public static class DependenciaConfig
    {
        public static IServiceCollection ResolveDependecias(this IServiceCollection service)
        {
            
            service.AddScoped<IGitHubService, GitHubService>();            

            return service;
        }
    }
}
