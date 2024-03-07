using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic {
    public class CustomerControl : ICRUD<Customer> {
        private readonly ICRUDAccess<Customer> _customerAccess;

    public CustomerControl(ICRUDAccess<Customer> customerAccess) { 
        _customerAccess = customerAccess;
        }

        public Task<int> Create(Customer entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<Customer> GetValue(int id) {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Customer entity) {
            throw new NotImplementedException();
        }
    }
}
