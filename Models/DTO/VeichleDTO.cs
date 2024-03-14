using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

[SwaggerDiscriminator("type")]
[SwaggerSubType(typeof(CarDTO), DiscriminatorValue = "Car")]
[SwaggerSubType(typeof(MotorcycleDTO), DiscriminatorValue = "Motorcycle")]
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(CarDTO), "Car")]
[JsonDerivedType(typeof(MotorcycleDTO), "Motorcycle")]
public abstract class VeichleDTO
{
    public abstract VeichleType Type { get; }
    public string Brand { get; set; } = string.Empty;
}
