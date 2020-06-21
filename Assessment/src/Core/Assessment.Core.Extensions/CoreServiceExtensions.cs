using Assessment.Core.Interfaces;
using Assessment.Core.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Assessment.Core.Extensions
{
    using static BaseService;
    public static class CoreServiceExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddMaps(new[] { "Assessment.Core.DTOs", "Assessment.Core.Entities", "Assessment.Core.ViewModels" });
            });
            var mapper = configuration.CreateMapper();
            services.AddTransient<IPromotionEngineService, PromotionEngineService>();
            services.AddSingleton(mapper);
            InitBaseService(services.BuildServiceProvider());
            return services;
        }
    }
}
