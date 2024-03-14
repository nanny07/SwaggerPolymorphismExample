# Swagger Polymorphism Example

A full example of how to use polymorphism in Swagger with DTO/BO, inheritance and automapper.

DTOs are for the response and BOs are for the request.

## Swagger

You have to register the polymorphism in the `Startup.cs` file.

```csharp
builder.Services.AddSwaggerGen((c) =>
{
    c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
});
```

In my case, I'm using the `Swashbuckle.AspNetCore.Annotations` package to mark only the class I want to include in swagger polymorphism.

```csharp
[SwaggerDiscriminator("type")]
[SwaggerSubType(typeof(CarDTO), DiscriminatorValue = "Car")]
[SwaggerSubType(typeof(MotorcycleDTO), DiscriminatorValue = "Motorcycle")]
```

You also have to add the `JsonConverter` to be sure that the serilization will work properly.

```csharp
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(CarDTO), "Car")]
[JsonDerivedType(typeof(MotorcycleDTO), "Motorcycle")]
```

This is specific to the `System.Text.Json` package: if you use Newtonsoft, you can use the `JsonSubtype` package without write the converter yourself.

## Automapper

This is alse a tricky part: I have used the `IncludeBase` method because it didn't worked with `IncludeAllDerivated` method.

```csharp
CreateMap<VeichleBO, Veichle>();

CreateMap<CarBO, Veichle>()
    .IncludeBase<VeichleBO, Veichle>();

CreateMap<MotorcycleBO, Veichle>()
    .IncludeBase<VeichleBO, Veichle>();
```

For the DTO we have to construct the derived type manually becasue VeichleDTO doesn't have a Configuration property.

```csharp
CreateMap<Veichle, VeichleDTO>()
    .ConstructUsing((src, dest) =>
    {
        switch (src.Type)
        {
            case VeichleType.Car:
                return new CarDTO() { Configuration = (CarConfiguration)src.Configuration };
            case VeichleType.Motorcycle:
                return new MotorcycleDTO() { Configuration = (MotorcycleConfiguration)src.Configuration };
            default:
                throw new ArgumentOutOfRangeException();
        }
    });
```