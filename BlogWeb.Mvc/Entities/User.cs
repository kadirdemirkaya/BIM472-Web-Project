using BlogWeb.Mvc.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ChangedAt { get; set; }
        public bool IsActive { get; set; } = true;


        public List<Comment> Comments { get; set; }

        public User()
        {

        }

        public User(string name, string email, string phoneNumber, string passwordHash = "123")
        {
            Id = Guid.NewGuid();
            UserName = name;
            Email = email;
            NormalizedEmail = email.ToUpper();
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }

        public User(Guid id, string name, string email, string phoneNumber, string passwordHash = "123")
        {
            Id = id;
            UserName = name;
            Email = email;
            NormalizedEmail = email.ToUpper();
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }

        public static User Create(Guid id, string name, string email, string phoneNumber = "0000000000", string passwordHash = "123")
            => new(id, name, email, phoneNumber, passwordHash);

        public static User Create(string name, string email, string phoneNumber = "0000000000", string passwordHash = "123")
            => new(name, email, phoneNumber, passwordHash);

        public void AssignRoleToUser(User user)
        {
            
        }
    }
}
