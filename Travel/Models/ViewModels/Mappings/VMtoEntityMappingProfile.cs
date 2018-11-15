using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Models.Entites;

namespace Travel.Models.ViewModels.Mappings
{
    public class VMToEntityMappingProfile : Profile
    {
        public VMToEntityMappingProfile()
        {
            CreateMap<RegistrationVM, User>().ForMember(usr => usr.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
