using FluentValidation;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using MinimalApiEx.Modules.Videos.Models;
using MinimalApiEx.Modules.Videos.Validators;

namespace MinimalApiEx.Modules.Videos;

internal sealed class VideoModule : IModule {
  public IServiceCollection RegisterModule(IServiceCollection services) {
    services.AddScoped<IValidator<GetVideosRequest>, GetVideosValidator>();

    return services;
  }

  public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
    endpoints.MapGet("/videos", GetVideos)
      .WithName(nameof(GetVideos))
      .WithOpenApi();

    return endpoints;
  }

  internal async Task<Results<Ok<string>, ValidationProblem>> GetVideos(
    [AsParameters] GetVideosRequest request,
    IValidator<GetVideosRequest> validator
  ) {
    var validationResult = await validator.ValidateAsync(request);

    return validationResult.IsValid
      ? (Results<Ok<string>, ValidationProblem>)TypedResults.Ok("some_url")
      : (Results<Ok<string>, ValidationProblem>)TypedResults.ValidationProblem(validationResult.ToDictionary());
  }
}
