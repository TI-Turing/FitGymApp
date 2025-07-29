using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gymmetry.Repository.Services
{
    public class LogErrorRepository : ILogErrorRepository
    {
        private readonly Gymmetry.Domain.Models.GymmetryContext _context;
        public LogErrorRepository(Gymmetry.Domain.Models.GymmetryContext context) { _context = context; }
        public async Task<bool> AddAsync(LogError log)
        {
            _context.LogErrors.Add(log);
            return await _context.SaveChangesAsync() > 0;
        }
    }
    public class LogLoginRepository : ILogLoginRepository
    {
        private readonly Gymmetry.Domain.Models.GymmetryContext _context;
        public LogLoginRepository(Gymmetry.Domain.Models.GymmetryContext context) { _context = context; }
        public async Task<bool> AddAsync(LogLogin log)
        {
            _context.LogLogins.Add(log);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<LogLogin> GetByUserIdAsync(Guid userId)
        {
            return await _context.LogLogins.Where(x=>x.UserId==userId && x.IsActive==true).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateAsync(LogLogin log)
        {
            _context.LogLogins.Update(log);
            return await _context.SaveChangesAsync() > 0;
        }
    }
    public class LogChangeRepository : ILogChangeRepository
    {
        private readonly Gymmetry.Domain.Models.GymmetryContext _context;
        public LogChangeRepository(Gymmetry.Domain.Models.GymmetryContext context) { _context = context; }
        public async Task<bool> AddAsync(LogChange log)
        {
            _context.LogChanges.Add(log);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddRangeAsync(IEnumerable<LogChange> logs)
        {
            await _context.LogChanges.AddRangeAsync(logs);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
