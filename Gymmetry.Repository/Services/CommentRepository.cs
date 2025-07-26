using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gymmetry.Repository.Services
{
    public class CommentRepository : ICommentRepository
    {
        private readonly GymmetryContext _context;

        public CommentRepository(GymmetryContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId && !c.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Comments.Where(c => c.UserId == userId && !c.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;
            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.UtcNow;
            _context.Comments.Update(comment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
