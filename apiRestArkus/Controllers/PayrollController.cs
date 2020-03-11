using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRestArkus.Constants;
using Common.Config;
using Common.DTO;
using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiRestArkus.Controllers
{
    [Route(ControllerContants.Payroll)]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly PayrollManager _payrollManager;

        public PayrollController(DataBaseContext dbContext)
        {
            this._payrollManager = new PayrollManager(dbContext);
        }

        [HttpPost(APIConstants.Save)]
        public ActionResult GeneratePayrolls()
        {
            try
            {
                this._payrollManager.GeneratePayrollsHistory();
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message.ToString() });
            }
        }

    }
}