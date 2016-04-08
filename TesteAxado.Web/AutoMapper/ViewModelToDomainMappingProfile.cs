using AutoMapper;
using TesteAxado.Domain.Entities;
using TesteAxado.Web.ViewModels;

namespace TesteAxado.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Rating, RatingViewModel>();
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<Carrier, CarrierViewModel>();

        }
    }
}