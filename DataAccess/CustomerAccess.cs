using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class CustomerAccess : ICRUDAccess<Customer> {
        private readonly ILogger<ICRUDAccess<Customer>>? _logger;

        public CustomerAccess(ILogger<ICRUDAccess<Customer>> logger = null) {
            _logger = logger;
        }

        public Task<int> Create(Customer entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(int id) {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Customer entity) {
            throw new NotImplementedException();
        }
    }
}
