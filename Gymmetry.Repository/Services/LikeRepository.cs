using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class LikeRepository : ILikeRepository
    {
        private readonly GymmetryContext _context;

        public LikeRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<Like> AddAsync(Like like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<Like?> GetByIdAsync(Guid id)
        {
            return await _context.Likes.FindAsync(id);
        }

        public async Task<IEnumerable<Like>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Likes.Where(l => l.PostId == postId && !l.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Like>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Likes.Where(l => l.UserId == userId && !l.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            return await _context.Likes.Where(l => !l.IsDeleted).ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like == null) return false;
            like.IsDeleted = true;
            like.DeletedAt = DateTime.UtcNow;
            _context.Likes.Update(like);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Like?> GetByPostAndUserAsync(Guid postId, Guid userId)
        {
            return await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId && !l.IsDeleted);
        }
    }
}
