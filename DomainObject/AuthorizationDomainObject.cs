using Common.Config;
using Common.DTO;
using Common.Interfaces;
using DAO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DomainObject
{
    public class AuthorizationDomainObject : IAuthorization
    {
        private readonly AuthorizationDAO _authorizationDAO;
        private readonly EmployerDAO _employerDAO;
        private readonly IConfiguration _config;
        public AuthorizationDomainObject(DataBaseContext dataBaseContext, IConfiguration config)
        {
            this._config = config;
            this._authorizationDAO = new AuthorizationDAO(dataBaseContext);
            this._employerDAO = new EmployerDAO(dataBaseContext);
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginD = null;
            try
            {
                var employer = this._employerDAO.GetByEmail(loginRequest.Email);

                if(employer != null)
                {
                    var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                    var password = BCrypt.Net.BCrypt.HashPassword(loginRequest.Password, salt);
                    if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, employer.Password))
                    {
                        loginD = new LoginResponse
                        {
                            Id = employer.Id,
                            Name = string.Format("{0} {1} {2}", employer.Name, employer.LastName, employer.MotherLastName),
                            Token = this.CreateToken(employer),
                            IsAdmin = employer.Role.Equals(1)
                        };
                    }
                    else
                    {
                        throw new Exception("Usuario o contraseña incorrecta");
                    }
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrecta");
                }

                return loginD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }            
        }

        #region Create Token
        public string CreateToken(EmployerDTO employerDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._config.GetSection("Jwt:Secret").Value);
            var name = string.Format("{0} {1} {2}", employerDTO.Name, employerDTO.LastName, employerDTO.MotherLastName);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, employerDTO.Id.ToString()),
                    new Claim(ClaimTypes.Name, name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        #endregion
    }
}
