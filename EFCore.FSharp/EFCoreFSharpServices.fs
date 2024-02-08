namespace EntityFrameworkCore.FSharp

open Microsoft.EntityFrameworkCore.Design
open Microsoft.Extensions.DependencyInjection

open EntityFrameworkCore.FSharp
open EntityFrameworkCore.FSharp.Internal
open Microsoft.EntityFrameworkCore.Migrations
open EntityFrameworkCore.FSharp.Migrations.Internal

type EFCoreFSharpServices(scaffoldOptions : ScaffoldOptions) =

    new() = EFCoreFSharpServices(ScaffoldOptions.Default)

    static member Default = EFCoreFSharpServices() :> IDesignTimeServices

    static member WithScaffoldOptions scaffoldOptions =
        EFCoreFSharpServices scaffoldOptions :> IDesignTimeServices

    interface IDesignTimeServices with
        member _.ConfigureDesignTimeServices(services : IServiceCollection) =
            services
                .AddSingleton<ScaffoldOptions>(scaffoldOptions)
                .AddSingleton<ICSharpHelper, FSharpHelper>()
                .AddSingleton<IMigrationsModelDiffer, FSharpMigrationsModelDiffer>()
                .AddSingleton<ICSharpEntityTypeGenerator, FSharpEntityTypeGenerator>()
                .AddSingleton<ICSharpDbContextGenerator, FSharpDbContextGenerator>()
                .AddSingleton<IModelCodeGenerator, FSharpModelGenerator>()
                .AddSingleton<ICSharpMigrationOperationGenerator, FSharpMigrationOperationGenerator>()
                .AddSingleton<ICSharpSnapshotGenerator, FSharpSnapshotGenerator>()
                .AddSingleton<IMigrationsCodeGenerator, FSharpMigrationsGenerator>()
                .AddSingleton<IMigrationsScaffolder, FSharpMigrationsScaffolder>()
                .AddSingleton<FSharpMigrationsGeneratorDependencies>()
            |> ignore
