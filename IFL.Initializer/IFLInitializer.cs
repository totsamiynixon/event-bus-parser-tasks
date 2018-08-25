
using IFL.DI;
using IFL.Initializer;
using IFL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectInicializer), "Start")]
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AutoMapperConfiguration), "Configure")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectInicializer), "Stop")]
namespace IFL.Initializer
{
    public static class IFLInitializer
    {
        public static void Initialize()
        {
            NinjectInicializer.Start();
            AutoMapperConfiguration.Configure();
        }
    }
}
