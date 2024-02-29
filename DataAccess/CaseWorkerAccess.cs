using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class CaseWorkerAccess : ICRUDAccess<CaseWorker> {
        private readonly ILogger<ICRUDAccess<CaseWorker>>? _logger;

        public CaseWorkerAccess(ILogger<ICRUDAccess<CaseWorker>>? logger = null) {
            _logger = logger;
        }
        public Task<int> Create(CaseWorker entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<CaseWorker> Get(int id) {
            throw new NotImplementedException();
        }

        public Task<List<CaseWorker>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, CaseWorker entity) {
            throw new NotImplementedException();
        }
    }
}

    
