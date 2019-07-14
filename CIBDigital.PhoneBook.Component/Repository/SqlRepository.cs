using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CIBDigital.PhoneBook.Settings;

namespace CIBDigital.PhoneBook.Component
{
    public class SqlRepository : ISqlRepository
    {
        private IDbConnection _dbConnection;
        private readonly ISqlConfiguration _sqlConfiguration;

        public SqlRepository(ISqlConfiguration sqlConfiguration) {
            _sqlConfiguration = sqlConfiguration;
            _dbConnection = new SqlConnection(_sqlConfiguration.ConnectionString);
        }

        public async Task<object> Insert(object param,string storedProc)
        {
            try
            {
                return await _dbConnection.QueryAsync(storedProc, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
            catch(Exception ex){
                throw ex;
            }
        }
        public async Task<List<T>> Get<T>(string storedProc)
        {
            try
            {
                var response  = await _dbConnection.QueryAsync<T>(storedProc, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
    }
}
