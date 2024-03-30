using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo { Title = "MyBGList", Version = "v1.0" }
    );

    options.SwaggerDoc(
        "v2",
        new OpenApiInfo { Title = "MyBgList", Version = "v2.0" }
    );

    options.SwaggerDoc(
        "v3",
        new OpenApiInfo { Title = "MyBGList", Version = "v3.0" }
    );
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
    });

    options.AddPolicy(name: "AnyOrigin_GetOnly", cfg =>
    {
        cfg.AllowAnyOrigin();
        cfg.AllowAnyHeader();
        cfg.WithMethods("GET");
    });
});

// enable api versioning
builder.Services.AddApiVersioning(options =>
{
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    // set version format 1.2.3
    options.GroupNameFormat = "'v'VVV";
    // replace the placeholder {ApiVersion} with the version number.
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    // use three version v1, v2, v3
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", "MyBGList v1");
        options.SwaggerEndpoint($"/swagger/v2/swagger.json", "MyBGList v2");
        options.SwaggerEndpoint($"/swagger/v3/swagger.json", "MyBGList v3");
    });
}


if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapGet("/v{version:ApiVersion}/error",
[ApiVersion("1.0")] // create v1 for this endpoint.
[ApiVersion("2.0")] // create v1 for this endpoint.
[EnableCors("AnyOrigin")] // any origin can use this endpoint.
[ResponseCache(NoStore = true)] // Typically, error responses are not cached as they respond to specific errors.
() => Results.Problem());

app.MapGet("/v{version:ApiVersion}/error/test",
[ApiVersion("1.0")] // create v1 for this endpoint.
[ApiVersion("2.0")] // create v1 for this endpoint.
[EnableCors("AnyOrigin")] // any origin can use this endpoint.
[ResponseCache(NoStore = true)] // Typically, error responses are not cached as they respond to specific errors.
() =>
{
    throw new Exception("Saleh, test!");
});

app.MapGet("/v{version:ApiVersion}/cod/test",
// [ApiVersion("1.0")] // create v1 for this endpoint.
[ApiVersion("2.0")] // create v1 for this endpoint.
// [EnableCors("AnyOrigin")] // any origin can use this endpoint.
[EnableCors("AnyOrigin_GetOnly")]
[ResponseCache(NoStore = true)] // Typically, error responses are not cached as they respond to specific errors.
() => Results.Text("<script>" +
        "window.alert('Your client supports JavaScript!" +
        "\\r\\n\\r\\n" +
        $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
        "\\r\\n" +
        "Client time (UTC): ' + new Date().toISOString());" +
        "</script>" +
        "<noscript>Your client does not support JavaScript</noscript>",
        "text/html"));

// If we want to add the flag "AnyOrigin" to a single endpoint
// that exists in a controller, we'll have to add that flag for ALL controllers and all their endpoints.
// It'd be like this: app.MapControllers().RequireCors("AnyOrigin")
// This is actually an advantege of Minimal APIs.
// Anyways, Microsoft recommends using the attribute [EnableCors]
// which can be used at the level of a controller or a single action.
app.MapControllers();

app.Run();
