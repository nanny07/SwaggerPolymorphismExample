public class MotorcycleDTO : VeichleDTO
{
    public override VeichleType Type => VeichleType.Motorcycle;
    public MotorcycleConfiguration Configuration { get; set; } = new();
}
