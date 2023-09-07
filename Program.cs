using MinimalApiEx.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen();
builder.Services.RegisterModules();

var app = builder.Build();
app.MapEndpoints();
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}

app.Run();
