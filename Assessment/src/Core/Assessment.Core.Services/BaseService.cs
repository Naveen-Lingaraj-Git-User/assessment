using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Core.Services
{
    public class BaseService
    {
        private static IServiceProvider ServiceProvider { get; set; }
        public static void InitBaseService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public static T Using<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
