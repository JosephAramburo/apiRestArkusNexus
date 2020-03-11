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

        [HttpGet(APIConstants.Filters)]
        public ActionResult GetByFilters([FromQuery] PayrollFiltersRequest payrollFiltersRequest)
        {
            try
            {
                var filters = this._payrollManager.GetByFilters(payrollFiltersRequest);
                return Ok(filters);
            }
            catch (Exception ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message.ToString() });
            }
        }

        [HttpGet(APIConstants.GetById)]
        public ActionResult GetById(int id, [FromQuery] PayrollFiltersRequest payrollFiltersRequest)
        {
            try
            {
                var filters = this._payrollManager.GetByEmployerIdAndYearAndMonth(id, payrollFiltersRequest.Year, payrollFiltersRequest.Month);
                return Ok(filters);
            }
            catch (Exception ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message.ToString() });
            }
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