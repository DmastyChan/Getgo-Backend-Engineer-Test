using AutoMapper;
using TT.GetGo.Core.Domain;
using TT.GetGo.Web.Models;

namespace TT.GetGo.Web.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Car -> CarModel
            CreateMap<Car, CarModel>()
                .ForMember(z => z.GeoX, w=> w.Ignore())
                .ForMember(z => z.GeoY, w=> w.Ignore())
                .ForMember(z => z.CreatedDateDesc, y => y.MapFrom(w  => w.CreatedUTCDate.ToLocalTime().ToString("yyyy-MMM-dd HH:mm tt")))
                .ForMember(z => z.Status, y => y.MapFrom(w => w.Status.ToString()));

            // CarInfo -> CarModel
            CreateMap<CarInfo, CarModel>()
                .ForMember(z => z.Id, w => w.MapFrom(y => y.Car.Id))
                .ForMember(z => z.CarName, w => w.MapFrom(y => y.Car.CarName))
                .ForMember(z => z.Brand, w => w.MapFrom(y => y.Car.Brand))
                .ForMember(z => z.Model, w => w.MapFrom(y => y.Car.Model))
                .ForMember(z => z.Color, w => w.MapFrom(y => y.Car.Color))
                .ForMember(z => z.NoPlate, w => w.MapFrom(y => y.Car.NoPlate))
                .ForMember(z => z.CreatedDateDesc,
                    y => y.MapFrom(w => w.Car.CreatedUTCDate.ToLocalTime().ToString("yyyy-MMM-dd HH:mm tt")))
                .ForMember(z => z.Status, y => y.MapFrom(w => w.Car.Status.ToString()))
                .ForMember(z => z.GeoX, w => w.MapFrom(y => y.LastGeoX))
                .ForMember(z => z.GeoY, w => w.MapFrom(y => y.LastGeoY));
        }
    }
}
