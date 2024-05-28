using BlogWeb.Mvc.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Entities
{
    public class Role : IdentityRole<Guid>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ChangedAt { get; set; }
        public bool IsActive { get; set; } = true;


        public Role()
        {

        }

        public Role(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            NormalizedName = name.ToUpper();
        }

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
            NormalizedName = name.ToUpper();
        }

        public static Role Create(string name)
            => new(name);

        public static Role Create(Guid id, string name)
            => new(id, name);
    }
}
