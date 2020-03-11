using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class StoreProcedureConstants
    {
        public const string CreateOrUpdateEmployer  = "sp_createOrUpdateEmployer";
        public const string DeleteEmployer          = "sp_DeleteEmployer";
        public const string GetEmployerById         = "sp_GetEmployerById";
        public const string GetEmployerByEmail      = "sp_GetEmployerByEmail";
        public const string GetEmployersByFilters   = "sp_GetEmployersByFilters";

        public const string GetPayrollsByFilters                    = "sp_GetPayrollsByFilters";
        public const string GetPayrollById                          = "sp_GetPayrollById";
        public const string GeneratePayrollsHistory                 = "sp_GeneratePayrollsHistory";
        public const string GetPayrollByEmpleadoIdAndYearAndMonth   = "sp_GetPayrollByEmpleadoIdAndYearAndMonth";
    }
}
