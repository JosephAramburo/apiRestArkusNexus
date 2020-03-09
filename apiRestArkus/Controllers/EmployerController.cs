using System;
using Common.DTO;
using Common.Config;
using Manager;
using Microsoft.AspNetCore.Mvc;
using apiRestArkus.Constants;

namespace apiRestArkus.Controllers
{
    [Route(ControllerContants.Employer)]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly EmployerManager _employerManager;
        private DataBaseContext _dbContext;

        public EmployerController(DataBaseContext dbContext)
        {            
            this._dbContext = dbContext;
            _employerManager = new EmployerManager(dbContext);
        }

        [HttpGet(APIConstants.Filters)]
        public ActionResult<EmployerFiltersResponse> GetByFilters([FromQuery] EmployerFiltersRequest employerFiltersRequest)
        {
            try
            {
                var result = this._employerManager.GetByFilters(employerFiltersRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message.ToString());
            }
        }

        [HttpGet(APIConstants.GetById)]
        public ActionResult<EmployerDTO> GetById(int id)
        {
            try
            {
                var result = this._employerManager.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message.ToString());
            }
        }

        [HttpPut(APIConstants.Update)]
        public ActionResult<EmployerDTO> Update(int id, [FromBody] EmployerDTO employerDTO)
        {
            try
            {
                var result = this._employerManager.Update(employerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message.ToString());
            }
        }

        [HttpPost(APIConstants.Save)]
        public ActionResult<EmployerDTO> Save([FromBody] EmployerDTO employerDTO)
        {
            try
            {
                var result = this._employerManager.Save(employerDTO);
                return Created("",result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message.ToString());
            }
        }

        [HttpDelete(APIConstants.Delete)]
        public ActionResult<EmployerDTO> Delete(int id)
        {
            try
            {
                var result = this._employerManager.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message.ToString());
            }
        }
    }
}