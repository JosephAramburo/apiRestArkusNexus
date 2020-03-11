using Common.Constants;
using Common.DTO;
using Common.Interfaces;
using Common.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAO
{
    public class EmployerDAO : IEmployer
    {
        private readonly DataBaseContext _dataBaseContext;

        public EmployerDAO(DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;            
        }

        public EmployerFiltersResponse GetByFilters(EmployerFiltersRequest employerFiltersRequest)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                    StoreProcedureConstants.GetEmployersByFilters,
                    ParametersConstants.Page,
                    ParametersConstants.Email,
                    ParametersConstants.ID,
                    ParametersConstants.Name,
                    ParametersConstants.Role,
                    ParametersConstants.Status,
                    ParametersConstants.Limit);

                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.Page,  SqlDbType.Int)          { Value = employerFiltersRequest.Page},
                    new SqlParameter(ParametersConstants.Email, SqlDbType.VarChar, 200) { Value = employerFiltersRequest.Email == null ? "" :  employerFiltersRequest.Email },
                    new SqlParameter(ParametersConstants.ID,    SqlDbType.Int)          { Value = employerFiltersRequest.Id},
                    new SqlParameter(ParametersConstants.Name,  SqlDbType.VarChar, 180) { Value = employerFiltersRequest.Name == null ? "" :  employerFiltersRequest.Name},
                    new SqlParameter(ParametersConstants.Role,  SqlDbType.Int)          { Value = employerFiltersRequest.Role },
                    new SqlParameter(ParametersConstants.Status,SqlDbType.Int)          { Value = employerFiltersRequest.Status},
                    new SqlParameter(ParametersConstants.Limit, SqlDbType.Int)          { Value = 5 }
                };

                var result = this._dataBaseContext.Set<EmployerFiltersResult>().FromSql(storeProcedure, listParameters.ToArray()).ToList();

                var employers = result.Select(x => new EmployerDTO
                {
                    Id              = x.Id,
                    Email           = x.Email,
                    Name            = x.Name,
                    LastName        = x.LastName,
                    MotherLastName  = x.MotherLastName,
                    AdmissionDate   = x.AdmissionDate,
                    Status          = x.Status,
                    Role            = x.Role
                }).ToList();

                return new EmployerFiltersResponse
                {
                    Page = employerFiltersRequest.Page,
                    Count = result.Count() > 0 ? result[0].Count : 0,
                    Employers = employers
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployerDTO GetByEmail(string email)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}", StoreProcedureConstants.GetEmployerByEmail, ParametersConstants.Email);
                var result = this._dataBaseContext.Employer.FromSql(storeProcedure, new SqlParameter(ParametersConstants.Email, email)).ToList();

                return result.Count() > 0 ? result[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public EmployerDTO GetById(int id)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}", StoreProcedureConstants.GetEmployerById, ParametersConstants.ID);             
                var result = this._dataBaseContext.Employer.FromSql(storeProcedure, new SqlParameter(ParametersConstants.ID, id)).ToList();

                return result.Count() > 0 ? result[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public EmployerDTO Delete(int id)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}, {2}, {3}, {4}", 
                    StoreProcedureConstants.DeleteEmployer, 
                    ParametersConstants.ID, 
                    ParametersConstants.Status,
                    ParametersConstants.UpdatedAt,
                    ParametersConstants.UpdatedBy);
                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.ID,        SqlDbType.Int) { Value = id },                    
                    new SqlParameter(ParametersConstants.Status,    SqlDbType.Bit) { Value = 0 },
                    new SqlParameter(ParametersConstants.UpdatedAt, SqlDbType.DateTime) { Value = DateTime.Now },
                    new SqlParameter(ParametersConstants.UpdatedBy, SqlDbType.Int) { Value = 1 },
                };

                var result = this._dataBaseContext.Employer.FromSql(storeProcedure, listParameters.ToArray()).ToList();

                return result.Count() > 0 ? result[0] : null;
            }
            catch (SqlException sqlE)
            {
                throw new Exception(sqlE.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            };
        }        

        public List<EmployerDTO> Pagination(EmployerDTO filters)
        {
            throw new NotImplementedException();
        }

        public EmployerDTO Save(EmployerDTO employerDTO)
        {
            try
            {
                return this.ExecuteCreateOrUpdate(1, employerDTO);
            }
            catch (SqlException sqlE)
            {
                throw new Exception(sqlE.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployerDTO Update(EmployerDTO employerDTO)
        {
            try
            {
                return this.ExecuteCreateOrUpdate(2, employerDTO);
            }
            catch (SqlException sqlE)
            {
                throw new Exception(sqlE.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private EmployerDTO ExecuteCreateOrUpdate(int typeCrud, EmployerDTO employerDTO)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}",
                    StoreProcedureConstants.CreateOrUpdateEmployer,
                    ParametersConstants.TypeScrud,
                    ParametersConstants.ID,
                    ParametersConstants.Email,
                    ParametersConstants.Password,
                    ParametersConstants.Role,
                    ParametersConstants.Name,
                    ParametersConstants.LastName,
                    ParametersConstants.MotherLastName,
                    ParametersConstants.Status,
                    ParametersConstants.AdmissionDate,
                    ParametersConstants.BaseIncome,
                    ParametersConstants.BreakfastDeduction,
                    ParametersConstants.SavingsDeduction,
                    ParametersConstants.GasolineCard,
                    ParametersConstants.CreatedAt,
                    ParametersConstants.CreatedBy,
                    ParametersConstants.UpdatedAt,
                    ParametersConstants.UpdatedBy
                );

                if (!employerDTO.Password.Equals(""))
                {
                    var salt             = BCrypt.Net.BCrypt.GenerateSalt(12);
                    employerDTO.Password = BCrypt.Net.BCrypt.HashPassword(employerDTO.Password, salt);
                }

                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.TypeScrud,             SqlDbType.Int)          { Value = typeCrud },
                    new SqlParameter(ParametersConstants.ID,                    SqlDbType.Int)          { Value = employerDTO.Id },
                    new SqlParameter(ParametersConstants.Email,                 SqlDbType.VarChar, 200) { Value = employerDTO.Email },
                    new SqlParameter(ParametersConstants.Password,              SqlDbType.VarChar, 250) { Value = employerDTO.Password },
                    new SqlParameter(ParametersConstants.Role,                  SqlDbType.Int)          { Value = employerDTO.Role },
                    new SqlParameter(ParametersConstants.Name,                  SqlDbType.VarChar, 60)  { Value = employerDTO.Name },
                    new SqlParameter(ParametersConstants.LastName,              SqlDbType.VarChar, 60)  { Value = employerDTO.LastName },
                    new SqlParameter(ParametersConstants.MotherLastName,        SqlDbType.VarChar, 60)  { Value =  employerDTO.MotherLastName },
                    new SqlParameter(ParametersConstants.Status,                SqlDbType.Bit)          { Value = employerDTO.Status },
                    new SqlParameter(ParametersConstants.AdmissionDate,         SqlDbType.DateTime)     { Value = employerDTO.AdmissionDate },
                    new SqlParameter(ParametersConstants.BaseIncome,            SqlDbType.Decimal)      { Value = employerDTO.BaseIncome,           Precision = 14, Scale = 2 },
                    new SqlParameter(ParametersConstants.BreakfastDeduction,    SqlDbType.Decimal)      { Value = employerDTO.BreakfastDeduction,   Precision = 14, Scale = 2 },
                    new SqlParameter(ParametersConstants.SavingsDeduction,      SqlDbType.Decimal)      { Value = employerDTO.SavingsDeduction,     Precision = 14, Scale = 2 },
                    new SqlParameter(ParametersConstants.GasolineCard,          SqlDbType.Decimal)      { Value = employerDTO.GasolineCard,         Precision = 14, Scale = 2 },
                    new SqlParameter(ParametersConstants.CreatedAt,             SqlDbType.DateTime)     { Value = DateTime.Now },
                    new SqlParameter(ParametersConstants.CreatedBy,             SqlDbType.Int)          { Value = employerDTO.CreatedBy },
                    new SqlParameter(ParametersConstants.UpdatedAt,             SqlDbType.DateTime)     { Value = DateTime.Now },
                    new SqlParameter(ParametersConstants.UpdatedBy,             SqlDbType.Int)          { Value = employerDTO.UpdatedBy }
                };

                var result = this._dataBaseContext.Employer.FromSql(storeProcedure, listParameters.ToArray()).ToList();

                return result.Count() > 0 ? result[0] : null;
            }
            catch (SqlException sqlE)
            {
                throw new Exception(sqlE.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            };
        }
    }
}
