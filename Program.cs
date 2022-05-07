using Conn;
using Conn.Impl;
using Microsoft.OpenApi.Models;
using Pubinno.Business;
using Pubinno.Repositories;
using Pubinno.Repositories.Impl;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Conn
var connString = builder.Configuration.GetValue<string>("DefaultConnection");
builder.Services.AddSingleton<IDatabaseConnectionFactory>(x => new SqlConnectionFactory(connString));
#endregion

builder.Services.AddScoped<ILocationRepo, LocationRepo>();

builder.Services.AddScoped<LocationBusiness>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<AddRequiredHeaderParameter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class AddRequiredHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        var invalidateParam = operation.Parameters.FirstOrDefault(f => f.Name == "IsInvalidate");
        if (invalidateParam != null)
            operation.Parameters.Remove(invalidateParam);

        operation.Parameters.Add(new OpenApiParameter
        {
            In = ParameterLocation.Header,
            Name = "api-key",
            Required = true
        });
    }
}