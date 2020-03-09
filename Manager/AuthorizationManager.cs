using Common.Config;
using Common.DTO;
using Common.Interfaces;
using DomainObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class AuthorizationManager : IAuthorization
    {
        private readonly AuthorizationDomainObject _authorizationDomainObject;
        public AuthorizationManager(DataBaseContext dataBaseContext, IConfiguration config)
        {
            this._authorizationDomainObject = new AuthorizationDomainObject(dataBaseContext, config);
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            try
            {
                return this._authorizationDomainObject.Login(loginRequest);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
