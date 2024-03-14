public class CarBO : VeichleBO
{
    public override VeichleType Type => VeichleType.Car;
    public CarConfiguration Configuration { get; set; } = new();
}
