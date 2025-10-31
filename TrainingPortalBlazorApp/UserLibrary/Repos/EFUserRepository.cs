using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Models;

namespace UserLibrary.Repos
{
    public class EFUserRepository : IUserRepository
    {
        UserDBContext ctx = new UserDBContext();
        public async Task<UserRole> LoginAsync(string userId, string password)
        {
            try
            {
                User user = await(from u in ctx.Users where (u.UserId == userId && u.Password==password) select u).FirstAsync();
                UserRole userRole = await (from ur in ctx.UserRoles where ur.UserId == userId select ur).FirstAsync();
                return userRole;
            }
            catch (Exception e)
            {
                throw new UserException("Invalid Credentials");
            }

        }

        public async Task RegisterAsync(string userId, string password)
        {
            try
            {
                User user = new User();
                user.UserId = userId;
                user.Password = password;
                await ctx.Users.AddAsync(user);
                UserRole userRole = new UserRole { UserId=userId, RoleId = 2};
                await ctx.UserRoles.AddAsync(userRole);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }

        }
    }
}
