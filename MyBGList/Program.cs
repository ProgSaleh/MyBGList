using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.ResolveConflictingActions((apiDesc) => apiDesc.First());
});

// handle CORS
builder.Services.AddCors(options =>
{
    // by default, any method or header coming from the specified
    // origins in the configuration with the key "AllowedOrigins" is allowed.
    options.AddDefaultPolicy(cfg =>
    {
        cfg.WithOrigins(builder.Configuration["AllowedOrigins"]);
        cfg.AllowAnyHeader();
        cfg.AllowAnyMethod();
    });

    // any request with any header from any origin with the flag "AnyOrigin" is allowed.
    options.AddPolicy(name: "AnyOrigin",
    cfg =>
    {
        cfg.AllowAnyOrigin();
        cfg.AllowAnyHeader();
        cfg.AllowAnyMethod();
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapGet("/error",
    [EnableCors("AnyOrigin")]
// Typically, error responses are not cached as they respond to specific errors.
[ResponseCache(NoStore = true)]
() => Results.Problem());

app.MapGet("/error/test",
    [EnableCors("AnyOrigin")]
// Typically, error responses are not cached as they respond to specific errors.
[ResponseCache(NoStore = true)]
() =>
{
    throw new Exception("Saleh, test!");
});

// If we want to add the flag "AnyOrigin" to a single endpoint
// that exists in a controller, we'll have to add that flag for ALL controllers and all their endpoints.
// It'd be like this: app.MapControllers().RequireCors("AnyOrigin")
// This is actually an advantege of Minimal APIs.
// Anyways, Microsoft recommends using the attribute [EnableCors]
// which can be used at the level of a controller or a single action.
app.MapControllers();

app.Run();
