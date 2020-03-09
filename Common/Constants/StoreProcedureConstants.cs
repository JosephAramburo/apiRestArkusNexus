using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class StoreProcedureConstants
    {
        public const string CreateOrUpdateEmployer  = "sp_createOrUpdateEmployer";
        public const string GetEmployerById         = "sp_GetEmployerById";
        public const string GetEmployerByEmail      = "sp_GetEmployerByEmail";
        public const string GetEmployersByFilters   = "sp_GetEmployersByFilters";
    }
}
