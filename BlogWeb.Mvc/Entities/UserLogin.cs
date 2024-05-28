using BlogWeb.Mvc.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Entities
{
    public class UserLogin : IdentityUserLogin<Guid>, IBaseEntity
    {
        
    }
}
