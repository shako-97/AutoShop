using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseHelper;
using AutoShop.Models;


namespace AutoShop.Repositories
{
    public class CarRepository
    {
        private string _ConnectionString = @"server =.\sqlexpress; database = AutoShop; integrated security = true ";
        private SqlDatabase _database;

        public CarRepository()
        {
            _database = new SqlDatabase(_ConnectionString, true);
        }

        public void Insert(Car car)
        {
            _database.ExecuteNonQuery("InsertCar_SP", CommandType.StoredProcedure, GetSqlParameters(car));
        }
        public void Update(Car car)
        {
            _database.ExecuteNonQuery("UpdateCars_SP", CommandType.StoredProcedure, GetSqlParametersWithID(car));
        }
        public void Delete(int ID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter() {
                ParameterName = "ID",
                Value = ID };
            _database.ExecuteNonQuery("DeleteCar_SP", CommandType.StoredProcedure, sqlParameter);
        }
        private SqlParameter[] GetSqlParameters(Car car)
        {
            int count = 0;
            var properties = typeof(Car).GetProperties();
            SqlParameter[] sqlParameter = new SqlParameter[properties.Length - 1];
            foreach (var property in properties)
            {
                if (property.Name == "ID")
                {
                    continue;
                }
                sqlParameter[count] = new SqlParameter()
                {
                    ParameterName = property.Name,
                    Value = property.GetValue(car)
                };
                count++;
            }
            return sqlParameter;
        }
        private SqlParameter[] GetSqlParametersWithID(Car car)
        {
            int count = 0;
            var properties = typeof(Car).GetProperties();
            SqlParameter[] sqlParameter = new SqlParameter[properties.Length ];
            foreach (var property in properties)
            {
                
                    sqlParameter[count] = new SqlParameter()
                    {
                        ParameterName = property.Name,
                        Value = property.GetValue(car)
                    };
                 count++;
            }
            return sqlParameter;
        }
        private int CountModelParameter()
        {
            var properties = typeof(Car).GetProperties();
            return properties.Length;
        }
    }
}
