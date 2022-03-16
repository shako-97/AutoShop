using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseHelper
{
    public class SqlDatabase
    {
        string _connectionString;
        bool _isSingletone;
        bool _isDisposed;
        SqlConnection _connection;

        public SqlDatabase(string connectionString, bool useSingletone)
        {
            _connectionString = connectionString;
            _isSingletone = useSingletone;
            _isDisposed = false;
        }
        public SqlConnection GetConnection()
        {
            IsNotDisposed();
            if (_connection == null || !_isSingletone)
            {
                _connection = new SqlConnection(_connectionString);
            }
            return _connection;
        }
        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                GetConnection().Open();
            }
            else
            {
                throw new InvalidOperationException("Connection is already open.");
            }
        }
        public SqlCommand GetCommand(string comandText)
        {
            return GetCommand(comandText, CommandType.Text);
        }

        public SqlCommand GetCommand(string commandText, CommandType commandType)
        {
            var cmd = GetConnection().CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            return cmd;
        }
        public SqlCommand GetCommand(string commandText, SqlParameter[] parameters)
        {
            return GetCommand(commandText, CommandType.Text, parameters);
        }
        public SqlCommand GetCommand(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            var cmd = GetConnection().CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);
            return cmd;
        }
        public int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            var cmd = GetCommand(commandText, commandType, parameters);
            try
            {
                OpenConnection();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

        }
        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
            _isDisposed = true;
        }
        public bool IsSingleTone()
        {
            if (!_isSingletone)
                throw new Exception("Transaction is only supported in SingleToneMode");
            return true;
        }

        public bool IsNotDisposed()
        {
            if (_isDisposed) throw new ObjectDisposedException("Object is disposed.");
            return true;
        }
    }
}
