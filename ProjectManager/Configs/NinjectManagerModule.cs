using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using ProjectManager.Core;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Core.Commands.Creational;
using ProjectManager.Core.Commands.Decorators;
using ProjectManager.Core.Commands.Factories;
using ProjectManager.Core.Commands.Listing;
using ProjectManager.Core.Common.Contracts;
using ProjectManager.Core.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Data.Factories;
using ProjectManager.Services;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ProjectManager.ConsoleClient.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateUserInternalName = "CreateUserInternal";
        private const string CreateProjectInternalName = "CreateProjectInternal";
        private const string CreateTaskInternalName = "CreateTaskInternal";
        private const string ListProjectDetailsInternalName = "ListProjectDetailsInternal";
        private const string ListProjectsInternalName = "ListProjectsInternal";

        private const string CacheableCommandName = "CacheableCommand";

        private const string CreateUserName = "CreateUser";
        private const string CreateProjectName = "CreateProject";
        private const string CreateTaskName = "CreateTask";
        private const string ListProjectDetailsName = "ListProjectDetails";
        private const string ListProjectsName = "ListProjects";

        public override void Load()
        {
            // Engine
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IValidator>().To<Validator>().InSingletonScope();

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            this.Bind<ICachingService>().To<CachingService>().InSingletonScope()
                .WithConstructorArgument(configurationProvider.CacheDurationInSeconds);

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            var cmdProcessor = this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();
            

            // Models Factory
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();

            // Command Factory
            this.Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();

            this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserInternalName);
            this.Bind<ICommand>().To<CreateProjectCommand>().Named(CreateProjectInternalName);
            this.Bind<ICommand>().To<CreateTaskCommand>().Named(CreateTaskInternalName);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named(ListProjectDetailsInternalName);
            this.Bind<ICommand>().To<ListProjectsCommand>().Named(ListProjectsInternalName);

            this.Bind<ICommand>().To<CacheableCommand>().Named(CacheableCommandName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(ListProjectsInternalName));

            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateUserName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateUserInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateProjectName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateProjectInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateTaskName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateTaskInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectDetailsName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(ListProjectDetailsInternalName));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectsName)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CacheableCommandName));

            //// Just another way to bind a factory
            //// This code should be used if you want to use auto-implemented factories from Ninject. 
            //// This way you can delete your CommandsFactory class.

            //this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            //this.Bind<ICommand>().ToMethod(ctx =>
            //{
            //    var commandName = (string)ctx.Parameters.Single().GetValue(ctx, null);

            //    try
            //    {
            //        return ctx.Kernel.Get<ICommand>(commandName);
            //    }
            //    catch (Exception)
            //    {

            //        throw new UserValidationException("No such command!");
            //    }


            //}).NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommandFromString(null));
            }
    }
}
