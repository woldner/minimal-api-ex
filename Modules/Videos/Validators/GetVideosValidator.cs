using FluentValidation;

using MinimalApiEx.Modules.Videos.Models;

namespace MinimalApiEx.Modules.Videos.Validators;

internal class GetVideosValidator : AbstractValidator<GetVideosRequest> {
  public GetVideosValidator() {
    RuleFor(request => request.Query)
      .NotEmpty();
  }
}
