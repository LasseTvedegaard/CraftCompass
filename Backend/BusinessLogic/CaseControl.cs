using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic {
    public class CaseControl : ICRUD<Case> {
        private readonly ICRUDAccess<Case> _caseAccess;

        public CaseControl(ICRUDAccess<Case> caseAccess) {
            _caseAccess = caseAccess;
        }

        public Task<int> Create(Case entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<List<Case>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<Case> GetValue(int id) {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Case entity) {
            throw new NotImplementedException();
        }
    }
}
