using Domain.Entities.v1.User;
using Domain.Interfaces.v1.User;
using Infrastructure.Core.Context.v1;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.v1.User
{

    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task AddAsync(UserEntity user)
        {
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsUser(string email)
        {
            return await _userContext.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<UserEntity?> GetUserByEmail(string email)
        {
            return await _userContext.Users.Where(x=> x.Email == email).FirstOrDefaultAsync();
        }
    }
}
