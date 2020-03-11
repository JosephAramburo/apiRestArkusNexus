using Common.Config;
using Common.DTO;
using Common.Interfaces;
using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DomainObject
{
    public class PayrollDomainObject : IPayroll
    {
        private readonly PayrollDAO _payrollDAO;

        public PayrollDomainObject(DataBaseContext dbContext)
        {
            this._payrollDAO = new PayrollDAO(dbContext);
        }

        public void GeneratePayrollsHistory()
        {
            try
            {
                this._payrollDAO.GeneratePayrollsHistory();
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
                return this._payrollDAO.GetByEmployerIdAndYearAndMonth(id, year, month);
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
                return this._payrollDAO.GetByFilters(payrollFiltersRequest);
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
                return this._payrollDAO.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
