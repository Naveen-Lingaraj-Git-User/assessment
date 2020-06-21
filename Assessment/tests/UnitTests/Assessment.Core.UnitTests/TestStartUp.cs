using Assessment.Core.Extensions;
using Assessment.Core.Interfaces;
using Assessment.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace Assessment.Core.UnitTests
{
    using static BaseService;

    [SetUpFixture]
    public class TestStartUp
    {
        private static IServiceProvider ServiceProvider { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddCoreServices();
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T Using<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
