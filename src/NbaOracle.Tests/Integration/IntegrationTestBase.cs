using System;
using System.IO;
using System.Threading.Tasks;
using AngleSharp;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.DocumentLoaders.Implementations;
using BuildingBlocks.FileSystem;
using BuildingBlocks.FileSystem.Implementations;
using BuildingBlocks.Serialization;
using BuildingBlocks.Serialization.Implementation;
using Microsoft.Extensions.Configuration;
using NbaOracle.Providers.BasketballReference.Teams;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace NbaOracle.Tests.Integration
{
    public abstract class IntegrationTestBase
    {
        private readonly Container _container;

        protected IntegrationTestBase()
        {
            _container = new Container
            {
                Options = 
                { 
                    DefaultLifestyle = Lifestyle.Scoped, 
                    DefaultScopedLifestyle = new AsyncScopedLifestyle()
                }
            };

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettingsTest.json", optional: false, reloadOnChange: false)
                .Build();

            _container.RegisterSingleton<ISerializer, NativeJsonSerializer>();
            _container.RegisterSingleton<IFileSystem, SystemIOFileSystem>();

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            _container.RegisterInstance<IBrowsingContext>(context);

            _container.Register<IDocumentLoader, AngleSharpHttpDocumentLoader>();
            _container.RegisterDecorator<IDocumentLoader, ValidateDocumentHttpStatusBehavior>();
            _container.RegisterDecorator<IDocumentLoader, WriteDocumentToFileSystemBehavior>();
            _container.RegisterDecorator<IDocumentLoader, LoadDocumentFromFileSystemBehavior>();

            _container.RegisterInstance(new TeamProviderSettings(configuration["BasketballReferenceBaseUrl"], configuration["BaseDirectoryPath"]));
            _container.Register<ITeamProvider, TeamProvider>();
        }


        protected async Task ExecuteTest(Func<Container, Task> test)
        {
            await using (AsyncScopedLifestyle.BeginScope(_container))
            {
                await test(_container);
            }
        }
    }
}