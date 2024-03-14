using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

[SwaggerDiscriminator("type")]
[SwaggerSubType(typeof(CarBO), DiscriminatorValue = "Car")]
[SwaggerSubType(typeof(MotorcycleBO), DiscriminatorValue = "Motorcycle")]
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(CarBO), "Car")]
[JsonDerivedType(typeof(MotorcycleBO), "Motorcycle")]
public abstract class VeichleBO
{
    public abstract VeichleType Type { get; }
    public string Brand { get; set; } = string.Empty;
}
