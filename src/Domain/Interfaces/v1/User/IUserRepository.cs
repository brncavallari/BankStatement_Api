using Domain.Entities.v1.User;

namespace Domain.Interfaces.v1.User
{
    public interface IUserRepository
    {
        Task AddAsync(UserEntity user);
        Task<bool> ExistsUser(string email);
    }
}
