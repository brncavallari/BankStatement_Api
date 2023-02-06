using AutoMapper;
using Domain.Commands.v1.User.Create;
using Domain.Entities.v1.User;

namespace Domain.MapperProfile.v1
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
