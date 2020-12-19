using System;
using System.IO;
using System.Threading.Tasks;
using AngleSharp;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.DocumentLoaders.Implementations;
using BuildingBlocks.FileSystem;
using BuildingBlocks.FileSystem.Implementations;
using BuildingBlocks.Parsers;
using BuildingBlocks.Serialization;
using BuildingBlocks.Serialization.Implementation;
using Microsoft.Extensions.Configuration;
using NbaOracle.Providers;
using NbaOracle.Providers.BasketballReference.Games.Details;
using NbaOracle.Providers.BasketballReference.Games.Details.Processors;
using NbaOracle.Providers.BasketballReference.Games.Results;
using NbaOracle.Providers.BasketballReference.Games.Results.Processors;
using NbaOracle.Providers.BasketballReference.Teams;
using NbaOracle.Providers.BasketballReference.Teams.Processors;
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

            var baseDirectoryPath = configuration["BaseDirectoryPath"];
            var basketballReferenceBaseUrl = configuration["BasketballReferenceBaseUrl"];

            _container.RegisterSingleton<ISerializer, NativeJsonSerializer>();
            _container.RegisterSingleton<IFileSystem, SystemIOFileSystem>();

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            _container.RegisterInstance<IBrowsingContext>(context);

            _container.Register<IDocumentLoader, AngleSharpHttpDocumentLoader>();
            _container.RegisterDecorator<IDocumentLoader, ValidateDocumentHttpStatusBehavior>(); 
            //_container.RegisterDecorator<IDocumentLoader, WriteDocumentToFileSystemBehavior>();
            //_container.RegisterDecorator<IDocumentLoader, LoadDocumentFromFileSystemBehavior>();

            _container.Register(typeof(IDocumentParser<>), typeof(IProvidersAssemblyMarker).Assembly);
            _container.Register(typeof(IDocumentParser<,>), typeof(IProvidersAssemblyMarker).Assembly);

            _container.RegisterInstance(new TeamProviderSettings(basketballReferenceBaseUrl, baseDirectoryPath));
            _container.Register<ITeamProvider, TeamProvider>();

            _container.RegisterInstance(new TeamProcessorFileSystemSettings(baseDirectoryPath));
            _container.Register<ITeamProcessor, WriteTeamDataToFileSystemProcessor>();

            _container.RegisterInstance(new MonthlyGameResultsProviderSettings(basketballReferenceBaseUrl, baseDirectoryPath));
            _container.Register<IMonthlyGameResultsProvider, MonthlyGameResultsProvider>();

            _container.RegisterInstance(new SeasonGameResultsProcessorSettings(baseDirectoryPath));
            _container.Register<ISeasonGameResultsProcessor, WriteSeasonGameResultsToFileSystemProcessor>();

            _container.RegisterInstance(new GameDetailsProviderSettings(basketballReferenceBaseUrl, baseDirectoryPath));
            _container.Register<IGameDetailsProvider, GameDetailsProvider>();

            _container.RegisterInstance(new GameDetailsProcessorSettings(baseDirectoryPath));
            _container.Register<IGameDetailsProcessor, WriteGameDetailsToFileSystemProcessor>();
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