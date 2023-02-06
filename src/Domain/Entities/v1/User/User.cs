
using Domain.Extensions.v1;
using System.Text;

namespace Domain.Entities.v1.User
{
    public class User
    {
        public User() { }
        public User(long id, string nome, string sobrenome, string email, string password)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Password = password;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public void CreateHash()
        {
            Password = HashExtension.GetHash(Password);
        }
    }
}
