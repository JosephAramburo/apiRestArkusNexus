using Common.Config;
using Common.DTO;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class AuthorizationDAO : IAuthorization
    {
        public readonly DataBaseContext _dataBaseContext;

        public AuthorizationDAO(DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
