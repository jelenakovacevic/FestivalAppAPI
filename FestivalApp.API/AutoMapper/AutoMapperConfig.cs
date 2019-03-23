using AutoMapper;
using FestivalApp.API.DTO;
using FestivalApp.Services;

namespace FestivalApp.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<FestivalType, FestivalTypeDTO>()
                    .ReverseMap();
            });
        }

        public static Destination Map<Source, Destination>(Source source)
        {
            return Mapper.Map<Source, Destination>(source);
        }
        public static Destination Map<Source, Destination>(Source source, Destination destination)
        {
            return Mapper.Map<Source, Destination>(source, destination);
        }
    }
}