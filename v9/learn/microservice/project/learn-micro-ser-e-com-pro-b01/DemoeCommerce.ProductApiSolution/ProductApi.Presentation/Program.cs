using ProductApi.Infras.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// set up custom AddInfrastructureService
builder.Services.AddInfrastructureService(builder.Configuration);

var app = builder.Build();

// use custom UseInfrastructurePolicy
app.UseInfrastructurePolicy();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    //// set up Swashbuckle.AspNetCore.SwaggerUI for display Swagger UI API
    //app.UseSwaggerUI(options => {
    //    options.SwaggerEndpoint("/openapi/v1.json", "api");
    //});
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
