using BlogWeb.Mvc.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Mvc.Entities
{
    public class UserClaim : IdentityUserClaim<Guid>, IBaseEntity
    {
       
    }
}
