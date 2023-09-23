using AutoMapper;
using ParkingMSApp.Application.Dtos.Car;
using ParkingMSApp.Application.Dtos.ParkingVehicle;
using ParkingMSApp.Application.Dtos.Vehicle;
using ParkingMSApp.Application.Features.Commands.ParkningVehicle.CreateParkingVehicle;

using ParkingMSApp.Domain.Entities;

namespace ParkingMSApp.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ExitParkingViewDto, ParkingVehicle>().ReverseMap();

            CreateMap<ParkingVehicle, ParkingVehicleViewDto>()
           .ForMember(dest => dest.Vehicles, opt => opt.MapFrom(src => src.Vehicles));

            CreateMap<Vehicle, VehicleViewDto>().ReverseMap();



            CreateMap<ParkingVehicleViewDto, VehicleViewDto>().ReverseMap();
            CreateMap<CreateParkingVehicleCommandRequest, Class1Vehicle>().ReverseMap();
            CreateMap<CreateParkingVehicleCommandRequest, Class2Vehicle>().ReverseMap();
            CreateMap<CreateParkingVehicleCommandRequest, Class3Vehicle>().ReverseMap();     
            
           

        }
    }
}
