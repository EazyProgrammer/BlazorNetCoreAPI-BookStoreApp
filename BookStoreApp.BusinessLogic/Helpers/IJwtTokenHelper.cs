using BookStoreApp.Repository;
using System.Security.Claims;

namespace BookStoreApp.BusinessLogic.Helpers
{
    public interface IJwtTokenHelper
    {
        string GenerateWebToken(ApplicationUser user, IList<string> roles, IList<Claim> dbClaims);
    }
}
