public class CarDTO : VeichleDTO
{
    public override VeichleType Type => VeichleType.Car;
    public CarConfiguration Configuration { get; set; } = new();
}
