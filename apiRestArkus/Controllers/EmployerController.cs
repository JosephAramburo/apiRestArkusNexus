using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Common.DTO;
using DAO.Config;
using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiRestArkus.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public ActionResult<EmployerDTO> GetById(int id)
        {
            try
            {
                //this._dbContext.Employer
                //List<EmployerDTO> find = this._dbContext.Employer.FromSql("EXEC sp_GetEmployerById @id", new SqlParameter("@id", 1)).ToList();
                var result = this._employerManager.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message.ToString());
            }
        }
       

    }
}