using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class CaseAccess : ICRUDAccess<Case> {
        private readonly ILogger<ICRUDAccess<Case>>? _logger;

        public CaseAccess(ILogger<ICRUDAccess<Case>>? logger = null) {
            _logger = logger;
        }

        public Task<int> Create(Case entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAll() {
            throw new NotImplementedException();
        }

        public Task<Case> Get(int id) {
            throw new NotImplementedException();
        }

        public Task<List<Case>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Case entity) {
            throw new NotImplementedException();
        }
    }
}
