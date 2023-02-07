using Domain.Extensions.v1;

namespace Domain.Entities.v1.User
{
    public class UserEntity
    {
        public UserEntity() { }
        public UserEntity(long id, string name, string lastName, string email, string password)
        {
            Id = id;
            Name = name;
            Lastname = lastName;
            Email = email;
            Password = password;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public void CreatePasswordHash()
        {
            Password = HashExtension.GetHash(Password);
        }
    }
}
