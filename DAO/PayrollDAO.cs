using Common.Config;
using Common.Constants;
using Common.DTO;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    public class PayrollDAO : IPayroll
    {
        private DataBaseContext _dataBaseContext;

        public PayrollDAO(DataBaseContext dbContext)
        {
            this._dataBaseContext = dbContext;
        }

        public void GeneratePayrollsHistory()
        {
            try
            {
                this._dataBaseContext.Database.ExecuteSqlCommand("EXEC " + StoreProcedureConstants.GeneratePayrollsHistory);
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PayrollFiltersResult GetByEmployerIdAndYearAndMonth(int id, int year, int month)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}, {2}, {3}",
                    StoreProcedureConstants.GetPayrollByEmpleadoIdAndYearAndMonth
                    , ParametersConstants.EmployerId
                    , ParametersConstants.Year
                    , ParametersConstants.Month);

                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.EmployerId,    SqlDbType.Int) { Value = id },
                    new SqlParameter(ParametersConstants.Year,          SqlDbType.Int) { Value = year },
                    new SqlParameter(ParametersConstants.Month,         SqlDbType.Int) { Value = month },
                };

                var result = this._dataBaseContext.PayrollFiltersResults.FromSql(storeProcedure, listParameters.ToArray()).ToList();

                return result.Count() > 0 ? result[0] : null;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PayrollFiltersResponse GetByFilters(PayrollFiltersRequest payrollFiltersRequest)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                    StoreProcedureConstants.GetPayrollsByFilters,
                    ParametersConstants.Page,
                    ParametersConstants.ID,
                    ParametersConstants.EmployerId,
                    ParametersConstants.NameEmployer,
                    ParametersConstants.EmailEmployer,
                    ParametersConstants.Month,
                    ParametersConstants.Year,
                    ParametersConstants.Status,
                    ParametersConstants.Limit);

                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.Page,          SqlDbType.Int)          { Value = payrollFiltersRequest.Page},
                    new SqlParameter(ParametersConstants.ID,            SqlDbType.Int)          { Value = payrollFiltersRequest.Id},
                    new SqlParameter(ParametersConstants.EmployerId,    SqlDbType.Int)          { Value = payrollFiltersRequest.Id},
                    new SqlParameter(ParametersConstants.NameEmployer,  SqlDbType.VarChar, 180) { Value = payrollFiltersRequest.NameEmployer  == null ? "" : payrollFiltersRequest.NameEmployer},
                    new SqlParameter(ParametersConstants.EmailEmployer, SqlDbType.VarChar, 200) { Value = payrollFiltersRequest.EmailEmployer == null ? "" : payrollFiltersRequest.EmailEmployer },
                    new SqlParameter(ParametersConstants.Month,         SqlDbType.SmallInt)     { Value = payrollFiltersRequest.Month },
                    new SqlParameter(ParametersConstants.Year,          SqlDbType.SmallInt)     { Value = payrollFiltersRequest.Year },
                    new SqlParameter(ParametersConstants.Status,        SqlDbType.Int)          { Value = payrollFiltersRequest.Status},
                    new SqlParameter(ParametersConstants.Limit,         SqlDbType.Int)          { Value = 5 }
                };

                var result = this._dataBaseContext.Set<PayrollFiltersResult>().FromSql(storeProcedure, listParameters.ToArray()).ToList();

                var payrolls = result.Select(x => new PayrollDTO
                {
                    Id                  = x.Id,
                    Email               = x.Email,
                    Name                = x.Name,
                    ReceiptPeriod       = x.ReceiptPeriod,
                    Year                = x.Year,
                    BaseIncome          = x.BaseIncome,
                    TotalPerception     = x.TotalPerception,
                    SavingMoney         = x.SavingMoney,
                    BreakfastDeduction  = x.BreakfastDeduction,
                    GasolineCard        = x.GasolineCard,
                    TotalDeduction      = x.TotalDeduction,
                    Status              = x.StatusEmployer,
                    Deposit             = x.Deposit,

                }).ToList();

                return new PayrollFiltersResponse
                {
                    Page        = payrollFiltersRequest.Page,
                    Count       = result.Count() > 0 ? result[0].Count : 0,
                    Payrolls    = payrolls
                };
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PayrollFiltersResult GetById(int id)
        {
            try
            {
                var storeProcedure = string.Format("EXEC {0} {1}",
                    StoreProcedureConstants.GetPayrollById
                    ,ParametersConstants.ID);

                var listParameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.ID,    SqlDbType.Int) { Value = id }
                };

                var result = this._dataBaseContext.Set<PayrollFiltersResult>().FromSql(storeProcedure, new SqlParameter(ParametersConstants.ID, id)).ToList();

                return result.Count() > 0 ? result[0] : null;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
