using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CraftPro_REST_Service.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase {

        private readonly ICRUD<Case> _caseControl;
        private readonly ILogger<CaseController> _logger;

        public CaseController(ICRUD<Case> caseControl, ILogger<CaseController> logger = null) {
            _caseControl = caseControl;
            _logger = logger;
        }

        
    }
}
