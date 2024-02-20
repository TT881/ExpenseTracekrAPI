using ExepnseTrackerAPI.Models;
using ExepnseTrackerAPI.Models.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExepnseTrackerAPI.Services
{
    public class ClsUser : ControllerBase
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

        public string ValidateUser(string name, string password)
        {
            try
            {
                var check = _dbContext.TblUser.Where(user => user.Name.ToLower() == name.ToLower() && 
                user.Password.ToLower() == password.ToLower()).FirstOrDefault();
                var json = "";
                if (check != null)
                {
                    var result = (from user in _dbContext.TblUser
                                  where user.Name == check.Name && user.Password == check.Password
                                  select new
                                  {
                                      user.Name,
                                      user.UserId,
                                  }).ToList();
                    if (result != null)
                    {
                        json = JsonConvert.SerializeObject(result.ToList(), Formatting.Indented);
                    } 
                }
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
    }
}
