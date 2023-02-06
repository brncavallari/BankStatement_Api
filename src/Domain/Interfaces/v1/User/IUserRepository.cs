namespace Domain.Interfaces.v1.User
{
    public interface IUserRepository
    {
        Task AddAsync(Domain.Entities.v1.User.User user);
    }
}
