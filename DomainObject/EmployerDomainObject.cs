using DAO.Config;
using Common.DTO;
using Common.Interfaces;
using DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainObject
{
    public class EmployerDomainObject : IEmployer
    {
        private readonly EmployerDAO employerDAO;

        public EmployerDomainObject(DataBaseContext dataBaseContext)
        {
            this.employerDAO = new EmployerDAO(dataBaseContext);
        }

        public EmployerDTO GetById(int id)
        {
            try
            {
                return this.employerDAO.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
