using Common.Constants;
using Common.DTO;
using Common.Interfaces;
using DAO.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class EmployerDAO : IEmployer
    {
        private readonly DataBaseContext _dataBaseContext;

        public EmployerDAO(DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;            
        }

        public EmployerDTO GetById(int id)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter(ParametersConstants.ID, id)
                };
               
                //this._dataBaseContext.Database.
                //this._dataBaseContext.Employer.
                //this._dataBaseContext.Employer.FromSql("", new SqlParameter(ParametersConstants.ID, id));
                //var find = this._dataBaseContext.Set<EmployerDTO>().FindAsync("EXEC sp_GetEmployerById @id", new SqlParameter("@id", 1));
                //List<EmployerDTO> find = dataBaseContext.Employer.FromSql("EXEC sp_GetEmployerById @id", new SqlParameter("@id", 1)).ToList();
                //using (var db = new DataBaseContext())
                //{

                //    var find = db.Employer.Find();
                //   // var sp = GetCommand(StoreProcedureConstants.CreateOrUpdateEmployer, parameters);
                //    //Execute(sp, parameters.ToArray<object>(), db);
                //}

                return new EmployerDTO
                {

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            //using (var db = new DataBaseContext())
            //{
            //    var sp = GetCommand(StoreProcedureConstants.CreateOrUpdateEmployer, parameters);
            //    Execute(sp, parameters.ToArray<object>(), db);
            //}
        }
    }
}
