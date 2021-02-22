using Dapper;
using MISA.eSHOP.DataLayer.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.eSHOP.DataLayer.Context
{
    #region DECLARE
    public class OnlineDbContext<T> : IDbContext<T> where T : class
    {
        string _connectionString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF726_VTThien_eShop;" +
                "Character Set= utf8;" +
                "User Id = dev;" +
                "Password = 12345678";
        /// <summary>
        /// Khai báo kết nối
        /// </summary>
        private readonly IDbConnection _dbConnection;
    #endregion

        #region CONTRUCTOR
        public OnlineDbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region METHOD

        public IEnumerable<T> Query(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn bằng proceduce
            var entites = _dbConnection.Query<T>(sqlCommand, parameters, commandType: commandType);

            // Trả về 
            return entites;
        }

        public T QueryFirst(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn bằng proceduce
            var entity = _dbConnection.Query<T>(sqlCommand, parameters, commandType: commandType).FirstOrDefault();

            // Trả về 
            return entity;
        }

        public int Excute(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text)
        {
            var result = _dbConnection.Execute(sqlCommand, parameters, commandType: commandType);
            return result;
        }
        #endregion
    }
}
