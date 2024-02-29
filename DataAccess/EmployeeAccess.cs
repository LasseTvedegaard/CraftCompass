using Dapper;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class EmployeeAccess : ICRUDAccess<Employee> {

        private readonly string? _connectionString;
        private readonly ILogger<ICRUDAccess<Employee>> _logger;

        public EmployeeAccess(IConfiguration configuration, ILogger<ICRUDAccess<Employee>> logger = null) {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
            this._logger = logger;
        }

        // Test
        public EmployeeAccess(string  connectionString) {
            _connectionString = connectionString;
        }

        public async Task<int> Create(Employee entity) {
            int insertedEmployeeId = -1;
            using (SqlConnection conn = new SqlConnection(_connectionString)) {
                conn.Open();
                var sql = @"INSERT INTO Employees
                            (Name,
                            phone,
                            email,
                            role)
                            OUTPUT INSERTED.employeeId
                            VALUES
                            (@name,
                            @phone,
                            @email,
                            @role)";
                try {
                    insertedEmployeeId = await conn.ExecuteScalarAsync<int>(sql, entity);
                } catch (Exception ex) {
                    insertedEmployeeId = -1;
                    _logger?.LogError(ex.Message);
                    throw;
                }
                return insertedEmployeeId;
            }
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<Employee> Get(int id) {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAll() {
            List<Employee>? foundEmployee;
            using (SqlConnection con = new SqlConnection(_connectionString)) {
                con.Open();
                var sql = @"SELECT
                                name,
                                phone,
                                email,
                                role
                            FROM
                                Employees";

                try {
                    foundEmployee = (await con.QueryAsync<Employee>(sql)).ToList();
                } catch (Exception ex) {
                    foundEmployee = null;
                    _logger?.LogError(ex, "Error message");
                }
            }
            return foundEmployee;
        }

        public Task<bool> Update(int id, Employee entity) {
            throw new NotImplementedException();
        }
    }
}
