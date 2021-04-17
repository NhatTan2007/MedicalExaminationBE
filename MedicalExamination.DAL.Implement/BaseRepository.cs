using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MedicalExamination.DAL.Implement
{
    public class BaseRepository
    {
        private readonly IConfiguration _config;
        protected IDbConnection connection;
        public BaseRepository(IConfiguration config)
        {
            _config = config;
            connection = new SqlConnection(_config.GetConnectionString("DbConnection"));
        }
    }
}
