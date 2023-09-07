namespace MinimalApiEx.Modules;

internal static class ModuleExtensions {
  private static readonly List<IModule> RegisteredModules = new();

  internal static IServiceCollection RegisterModules(this IServiceCollection services) {
    var modules = DiscoverModules();

    foreach (var module in modules) {
      module.RegisterModule(services);
      RegisteredModules.Add(module);
    }

    return services;
  }

  internal static WebApplication MapEndpoints(this WebApplication app) {
    foreach (var module in RegisteredModules) {
      module.MapEndpoints(app);
    }

    return app;
  }

  private static IEnumerable<IModule> DiscoverModules() {
    return typeof(IModule).Assembly
      .GetTypes()
      .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
      .Select(Activator.CreateInstance)
      .Cast<IModule>();
  }
}
