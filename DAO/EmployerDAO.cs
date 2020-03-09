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
                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.ID, id),
                };
                var result = this._dataBaseContext.Employer.FromSql(storeProcedure, listParameters).ToList();

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
                var storeProcedure = string.Format("EXEC {0} {1}, {2}", StoreProcedureConstants.CreateOrUpdateEmployer, ParametersConstants.ID, ParametersConstants.TypeScrud);
                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.ID, id),
                    new SqlParameter(ParametersConstants.TypeScrud, 3)
                };

                var result = this._dataBaseContext.Employer.FromSql(storeProcedure, listParameters).ToList();

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
            List<string> listString = new List<string>
            {
                StoreProcedureConstants.CreateOrUpdateEmployer,
                ParametersConstants.TypeScrud,
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
                ParametersConstants.SavingsDeduction
            };
            
            var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.TypeScrud, typeCrud),
                    new SqlParameter(ParametersConstants.Email, employerDTO.Email),
                    new SqlParameter(ParametersConstants.Password, employerDTO.Password),
                    new SqlParameter(ParametersConstants.Role, employerDTO.Role),
                    new SqlParameter(ParametersConstants.Name, employerDTO.Name),
                    new SqlParameter(ParametersConstants.LastName, employerDTO.LastName),
                    new SqlParameter(ParametersConstants.MotherLastName, employerDTO.MotherLastName),
                    new SqlParameter(ParametersConstants.Status, employerDTO.Status),
                    new SqlParameter(ParametersConstants.AdmissionDate, employerDTO.AdmissionDate),
                    new SqlParameter(ParametersConstants.BaseIncome, employerDTO.BaseIncome),
                    new SqlParameter(ParametersConstants.BreakfastDeduction, employerDTO.BreakfastDeduction),
                    new SqlParameter(ParametersConstants.SavingsDeduction, employerDTO.SavingsDeduction)                    
                };

            if (typeCrud.Equals(1))
            {
                listString.Add(ParametersConstants.CreatedAt);
                listString.Add(ParametersConstants.CreatedBy);                
                listParameters.Add(new SqlParameter(ParametersConstants.CreatedAt, DateTime.Now));
                listParameters.Add(new SqlParameter(ParametersConstants.CreatedBy, employerDTO.CreatedBy));
            }
            else
            {
                listString.Add(ParametersConstants.UpdatedAt);
                listString.Add(ParametersConstants.UpdatedBy);
                listParameters.Add(new SqlParameter(ParametersConstants.UpdatedAt, DateTime.Now));
                listParameters.Add(new SqlParameter(ParametersConstants.UpdatedBy, employerDTO.UpdatedBy));
            }

            var storeProcedure = string.Format("EXEC {0} {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}", listString.ToArray());
            var result = this._dataBaseContext.Employer.FromSql(storeProcedure, listParameters).ToList();

            return result.Count() > 0 ? result[0] : null;
        }
    }
}
