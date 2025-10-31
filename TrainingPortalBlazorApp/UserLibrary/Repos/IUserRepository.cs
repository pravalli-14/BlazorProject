using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Models;

namespace UserLibrary.Repos
{
    public interface IUserRepository
    {
        Task<UserRole> LoginAsync(string userId,string password);
        Task RegisterAsync(string userId,string password);
    }
}
