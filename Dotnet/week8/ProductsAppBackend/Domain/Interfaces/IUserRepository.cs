using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash);
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
    }
}
