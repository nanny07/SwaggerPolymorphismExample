using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Treat Enum as string
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c) =>
{
    // Required for Polymorphic types and attributes
    c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/veichle", (VeichleBO veichle, [FromServices] IMapper mapper) =>
{
    var mappedEntity = mapper.Map<Veichle>(veichle);

    var mappedDTO = mapper.Map<VeichleDTO>(mappedEntity);

    return mappedDTO;
})
.WithName("PostVeichle")
.WithOpenApi();

app.MapGet("/veichles", ([FromServices] IMapper mapper) =>
{
    var veichles = new List<Veichle>
    {
        new Veichle
        {
            Type = VeichleType.Car,
            Brand = "Fiat",
            Configuration = new CarConfiguration
            {
                Doors = 4
            }
        },
        new Veichle
        {
            Type = VeichleType.Motorcycle,
            Brand = "Honda",
            Configuration = new MotorcycleConfiguration
            {
                Sidecar = true
            }
        }
    };

    return mapper.Map<List<VeichleDTO>>(veichles);
})
.WithName("GetVeichles")
.WithOpenApi();

app.Run();