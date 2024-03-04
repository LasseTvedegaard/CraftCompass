using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class WorkAddressAccess : ICRUDAccess<WorkAddress> {
        private readonly ILogger<ICRUDAccess<WorkAddress>>? _logger;

        public WorkAddressAccess(ILogger<ICRUDAccess<WorkAddress>>? logger) {
            _logger = logger;
        }

        public Task<int> Create(WorkAddress entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAll() {
            throw new NotImplementedException();
        }

        public Task<WorkAddress> Get(int id) {
            throw new NotImplementedException();
        }

        public Task<List<WorkAddress>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, WorkAddress entity) {
            throw new NotImplementedException();
        }
    }
}
