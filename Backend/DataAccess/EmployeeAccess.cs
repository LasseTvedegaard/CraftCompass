﻿using Dapper;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;
using System.Data.SqlClient;

namespace DataAccess {
    public class EmployeeAccess : ICRUDAccess<Employee> {
        private readonly string _connectionString;
        private readonly ILogger<ICRUDAccess<Employee>> _logger;

        // Denne konstruktør bruges i produktionskode
        public EmployeeAccess(IConfiguration configuration, ILogger<ICRUDAccess<Employee>> logger = null) {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
            _logger = logger;
        }

        // Denne konstruktør bruges i testkode, hvor forbindelsesstrengen gives direkte
        public EmployeeAccess(string connectionString) {
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

        public async Task<bool> Delete(int id) {
            int rowsAffected = -1;
            using (SqlConnection con = new SqlConnection(_connectionString)) {
                con.Open();
                var sql = @"DELETE FROM Employees WHERE EmployeeId = @id
";
                rowsAffected = await con.ExecuteAsync(sql, new { id });
            }
            return rowsAffected > 0;
        }

        public async Task<Employee> Get(int id) {
            using (var conn = new SqlConnection(_connectionString)) {
                conn.Open();
                var sql = @"SELECT * FROM Employees WHERE EmployeeId = @Id";
                try {
                    return await conn.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
                } catch (Exception ex) {
                    _logger?.LogError(ex, "Error getting employee with id {Id}", id);
                    throw;
                }
            }
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

        public async Task<bool> Update(int id, Employee employeeToUpdate) {
            int rowsAffected = -1;
            using (SqlConnection conn = new SqlConnection(_connectionString)) {
                conn.Open();
                var sql = @"UPDATE employees
                            SET
                                name = @name,
                                phone = @phone,
                                email = @email,
                                role = @role
                            WHERE
                                employeeId = @employeeId";

                rowsAffected = await conn.ExecuteAsync(sql, employeeToUpdate);
            }
            return rowsAffected > 0;
        }

        // For test tear down
        public async Task<bool> DeleteAll() {
            using (var conn = new SqlConnection(_connectionString)) {
                conn.Open();
                var sql = @"DELETE FROM Employees";
                var rowsAffected = await conn.ExecuteAsync(sql);
                return rowsAffected > 0;
            }
        }
    }

}

