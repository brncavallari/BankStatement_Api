namespace Infrastructure.Data.Repositories.v1.User
{
    using Domain.Entities.v1.User;
    using Domain.Interfaces.v1.User;
    using Infrastructure.Core.Context.v1;
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task AddAsync(User user)
        {
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        }
    }
}
