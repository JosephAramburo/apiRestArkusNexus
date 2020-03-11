using Common.Config;
using Common.DTO;
using Common.Interfaces;
using DomainObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class PayrollManager : IPayroll
    {
        private readonly PayrollDomainObject _payrollDomainObject;

        public PayrollManager(DataBaseContext dbContext)
        {
            this._payrollDomainObject = new PayrollDomainObject(dbContext);
        }

        public void GeneratePayrollsHistory()
        {
            try
            {
                this._payrollDomainObject.GeneratePayrollsHistory();
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
                return this._payrollDomainObject.GetByEmployerIdAndYearAndMonth(id, year, month);
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
                return this._payrollDomainObject.GetByFilters(payrollFiltersRequest);
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
                return this._payrollDomainObject.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
