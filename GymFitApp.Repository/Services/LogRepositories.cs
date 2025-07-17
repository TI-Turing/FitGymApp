using FitGymApp.Domain.Models;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitGymApp.Repository.Services
{
    public class LogErrorRepository : ILogErrorRepository
    {
        private readonly FitGymApp.Domain.Models.FitGymAppContext _context;
        public LogErrorRepository(FitGymApp.Domain.Models.FitGymAppContext context) { _context = context; }
        public async Task<bool> AddAsync(LogError log)
        {
            _context.LogErrors.Add(log);
            return await _context.SaveChangesAsync() > 0;
        }
    }
    public class LogLoginRepository : ILogLoginRepository
    {
        private readonly FitGymApp.Domain.Models.FitGymAppContext _context;
        public LogLoginRepository(FitGymApp.Domain.Models.FitGymAppContext context) { _context = context; }
        public async Task<bool> AddAsync(LogLogin log)
        {
            _context.LogLogins.Add(log);
            return await _context.SaveChangesAsync() > 0;
        }
    }
    public class LogChangeRepository : ILogChangeRepository
    {
        private readonly FitGymApp.Domain.Models.FitGymAppContext _context;
        public LogChangeRepository(FitGymApp.Domain.Models.FitGymAppContext context) { _context = context; }
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
