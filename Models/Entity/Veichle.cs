// DB entity
public class Veichle
{
    public VeichleType Type { get; set; }
    public string Brand { get; set; } = string.Empty;
    public object Configuration { get; set; } = new();
}
