using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using back.Database.Models;

namespace back.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        private readonly string SP_CreateUser = "SP_CreateUser";
        private readonly string SP_GetUser = "SP_GetUser";
        private readonly string SP_UpdateUser = "SP_UpdateUser";
        private readonly string SP_DelteteUser = "SP_DeleteUser";

        public UserRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IDbConnection ConnetionToDb
        {
            get 
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection")); //TODO
            }
        }

        public async Task CreateUser(CreateUserDb request) 
        {
            try 
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", request.Name);
                parameters.Add("@PhoneNumer", request.PhoneNumber);
                parameters.Add("@Email", request.Email);
                parameters.Add("@Password", request.Password);

                using (IDbConnection conn = ConnetionToDb) 
                {
                    await conn.QueryFirstOrDefaultAsync(this.SP_CreateUser, parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error in CreateUser -> {ex}");
            }
        }
    }
}