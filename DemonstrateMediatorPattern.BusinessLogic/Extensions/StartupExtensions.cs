using AutoMapper;
using DemonstrateMediatorPattern.BusinessLogic.Features.Shared;
using DemonstrateMediatorPattern.BusinessLogic.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemonstrateMediatorPattern.BusinessLogic.Extensions
{
    public static class StartupExtensions
    {
        public static void AddBusinessLogicServiceCollection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddMediatRConfiguration();
            serviceCollection.AddAutoMapperConfiguration();
            serviceCollection.AddFluentValidationConfiguration();
            //serviceCollection.AddIntegrations();
            //serviceCollection.AddConfigurations(configuration);
            //serviceCollection.AddServiceReferences();
        }

        public static void AddAutoMapperConfiguration(this IServiceCollection serviceCollection)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessMappingProfile());
            });

            mappingConfig.AssertConfigurationIsValid();

            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        private static void AddMediatRConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        }

        private static void AddFluentValidationConfiguration(this IServiceCollection serviceCollection)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(r => serviceCollection.AddScoped(r.InterfaceType, r.ValidatorType));
        }
    }
}
