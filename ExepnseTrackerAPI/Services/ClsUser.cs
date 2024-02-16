using ExepnseTrackerAPI.Models;
using ExepnseTrackerAPI.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExepnseTrackerAPI.Services
{
    public class ClsUser
    {
        private readonly ExpenseDbContext _dbContext;

        public ClsUser(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IActionResult> AddUserAsync(TblUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _dbContext.TblUser.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(user);
        }

        public async Task<List<TblUser>> GetUsersAsync()
        {
            var users = await _dbContext.TblUser.AsNoTracking().ToListAsync();
            return users;
        }
    }
}
