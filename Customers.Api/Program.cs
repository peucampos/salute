using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Doctors.Api.Repositories;
using Doctors.Api.Services;
using Doctors.Api.Settings;
using Doctors.Api.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

var config = builder.Configuration;
config.AddEnvironmentVariables("CustomersApi_");

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<Program>();
    x.DisableDataAnnotationsValidation = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(config.GetSection(DatabaseSettings.KeyName));

var credentials = new BasicAWSCredentials("AKIAQDFJQWNUEBO4V7XS", "JDLshQLDmXGHb5Z6aktBl9S+n2IsbpmW0hJYcyt3");
var awsconfig = new AmazonDynamoDBConfig()
{
    RegionEndpoint = RegionEndpoint.SAEast1
};

builder.Services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(credentials, awsconfig));
builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IDoctorService, DoctorService>();

var app = builder.Build();

// Configure the HTTP request pipeline. AKIAQDFJQWNUCBA6Z54C  JLi7A3dxY2XQLYr+ybg+Y3ID86/MiofKJ1RTHHdt
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
