using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Database.Models;

namespace back.Database.Repositories
{
    public interface IUserRepository
    {
        public Task CreateMember(CreateUserDb request);
    }
}