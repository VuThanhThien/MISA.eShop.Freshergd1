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

    public class LocalDbContext<T> : IDbContext<T> where T : class
    {
        #region DECLARE
        /// <summary>
        /// Khai báo chuỗi kết nối tới db
        /// </summary>
        string _connectionString = "Host = 127.0.0.1;" +
                "Port = 3306;" +
                "Database = mf726_eshop;" +
                "User Id = root;" +
                "Password = ";
        /// <summary>
        /// Khai báo kết nối
        /// </summary>
        private readonly IDbConnection _dbConnection;
        #endregion

        #region CONTRUCTOR
        public LocalDbContext()
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
