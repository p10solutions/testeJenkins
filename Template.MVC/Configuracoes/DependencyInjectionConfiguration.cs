using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Cadastro.Infra.CrossCutting.IoC;

namespace Template.MVC.Configuracoes
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            BootsTrapper.Registrar(services);
        }
    }
}
