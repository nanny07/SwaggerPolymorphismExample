public class MotorcycleBO : VeichleBO
{
    public override VeichleType Type => VeichleType.Motorcycle;
    public MotorcycleConfiguration Configuration { get; set; } = new();
}
