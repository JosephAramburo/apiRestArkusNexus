using Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IPayroll
    {
        void GeneratePayrollsHistory();
        PayrollFiltersResponse GetByFilters(PayrollFiltersRequest payrollFiltersRequest);
        PayrollFiltersResult GetById(int id);
        PayrollFiltersResult GetByEmployerIdAndYearAndMonth(int id, int year, int month);
    }
}
