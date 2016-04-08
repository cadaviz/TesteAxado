using AutoMapper;
using TesteAxado.Domain.Entities;
using TesteAxado.Web.ViewModels;

namespace TesteAxado.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure() {
            Mapper.CreateMap<RatingViewModel, Rating>();
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<CarrierViewModel, Carrier>();

        }
    }
}