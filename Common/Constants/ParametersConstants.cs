using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class ParametersConstants
    {

        #region Paramters StoreProcedure Generals
        public const string ID          = "@id";
        public const string TypeScrud   = "@typeCrud";
        public const string Status      = "@status";
        public const string CreatedAt   = "@createdAt";
        public const string CreatedBy   = "@createdBy";
        public const string UpdatedAt   = "@updatedAt";
        public const string UpdatedBy   = "@updatedBy";
        public const string Year        = "@year";
        public const string Month       = "@month";
        #endregion

        #region Parameters StoreProcedure
        public const string Email               = "@email";
        public const string Password            = "@password";
        public const string Role                = "@role";
        public const string Name                = "@name";
        public const string LastName            = "@lastName";
        public const string MotherLastName      = "@motherLastName";
        public const string AdmissionDate       = "@admissionDate";
        public const string BaseIncome          = "@baseIncome";
        public const string BreakfastDeduction  = "@breakfastDeduction";
        public const string SavingsDeduction    = "@savingsDeduction";
        public const string GasolineCard        = "@gasolineCard";
        public const string Page                = "@page";
        public const string Limit               = "@limit";

        public const string EmployerId          = "@employerId";
        public const string EmailEmployer       = "@emailEmployer";
        #endregion
    }
}
