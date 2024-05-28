using BlogWeb.Mvc.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Entities
{
    public class UserRole : IdentityUserRole<Guid>, IBaseEntity
    {
       
    }
}
