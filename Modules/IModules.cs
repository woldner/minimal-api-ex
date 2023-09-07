namespace MinimalApiEx.Modules;

internal interface IModule {
  IServiceCollection RegisterModule(IServiceCollection builder);
  IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}

