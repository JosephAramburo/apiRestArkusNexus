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
using Microsoft.Extensions.Configuration;

namespace apiRestArkus.Controllers
{
    [Route(ControllerContants.Authorization)]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly AuthorizationManager _authorizationManager;
        private DataBaseContext _dbContext;

        public AuthorizationController(DataBaseContext dbContext, IConfiguration config)
        {
            this._dbContext = dbContext;
            _authorizationManager = new AuthorizationManager(dbContext, config);
        }

        [HttpPost(APIConstants.Login)]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var result = this._authorizationManager.Login(loginRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message.ToString() });
            }
        }

    }
}