public class MotorcycleDTO : VeichleDTO
{
    public override VeichleType Type => VeichleType.Motorcycle;
    public bool? Sidecar { get; set; }
    public MotorcycleConfiguration Configuration { get; set; } = new();
}
