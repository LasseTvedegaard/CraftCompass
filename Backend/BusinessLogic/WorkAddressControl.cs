using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic {
    public class WorkAddressControl : ICRUD<WorkAddress> {

        private readonly ICRUDAccess<WorkAddress> _workAddress;

        public WorkAddressControl(ICRUDAccess<WorkAddress> workAddress) {
            _workAddress = workAddress;
        }

        public Task<int> Create(WorkAddress entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<List<WorkAddress>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<WorkAddress> GetValue(int id) {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, WorkAddress entity) {
            throw new NotImplementedException();
        }
    }
}
