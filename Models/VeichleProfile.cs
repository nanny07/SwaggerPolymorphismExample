using AutoMapper;

public class VeichleProfile : Profile
{
    public VeichleProfile()
    {
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

        CreateMap<VeichleBO, Veichle>();

        CreateMap<CarBO, Veichle>()
            .IncludeBase<VeichleBO, Veichle>();

        CreateMap<MotorcycleBO, Veichle>()
            .IncludeBase<VeichleBO, Veichle>();
    }
}