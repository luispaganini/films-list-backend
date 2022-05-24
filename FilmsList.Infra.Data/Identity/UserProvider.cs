using System.Security.Claims;
using FilmsList.Domain.Account;
using Microsoft.AspNetCore.Http;

namespace FilmsList.Infra.Data.Identity
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider (IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string GetUserId()
        {
            return _context.HttpContext.User.Claims
                       .First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}