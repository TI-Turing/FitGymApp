using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Repository.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly GymmetryContext _context;
        public AuthRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                (u.IsActive ?? false) &&
                (u.UserName == request.UserNameOrEmail || u.Email == request.UserNameOrEmail)
                && u.Password == request.Password
            );
            if (user == null) return null;
            return new LoginResponse
            {
                UserId = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email
            };
        }
    }
}