using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CraftPro_REST_Service.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CaseWorkerController : ControllerBase {

        private readonly ICRUD<CaseWorker> _caseWorkerControl;
        private readonly ILogger<CaseWorkerController> _logger;

        public CaseWorkerController(ICRUD<CaseWorker> caseWorkerControl, ILogger<CaseWorkerController> logger = null) {
            _caseWorkerControl = caseWorkerControl;
            _logger = logger;
        }
    }
}
