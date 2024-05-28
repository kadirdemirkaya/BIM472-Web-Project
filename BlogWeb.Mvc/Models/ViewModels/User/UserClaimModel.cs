using BlogWeb.Mvc.Entities;

namespace BlogWeb.Mvc.Models.ViewModels.User
{
    public class UserClaimModel
    {
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public UserClaimModel()
        {

        }
        public UserClaimModel(Guid userId, string claimType, string claimValue)
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public UserClaimModel UserClaimMapper(Guid userId, string claimType, string claimValue)
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;

            return this;
        }

        public List<UserClaimModel> UserClaimMapper(List<UserClaim> userClaims)
        {
            List<UserClaimModel> userClaimModels = new();

            foreach (var userClaim in userClaims)
                userClaimModels.Add(new(userClaim.UserId, userClaim.ClaimType, userClaim.ClaimValue));

            return userClaimModels;
        }
    }
}
