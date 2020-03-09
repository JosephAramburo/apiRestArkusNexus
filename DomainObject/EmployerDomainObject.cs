using Common.Config;
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

        public EmployerFiltersResponse GetByFilters(EmployerFiltersRequest employerFiltersRequest)
        {
            try
            {
                return this.employerDAO.GetByFilters(employerFiltersRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public EmployerDTO Delete(int id)
        {
            try
            {
                return this.employerDAO.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public List<EmployerDTO> Pagination(EmployerDTO filters)
        {
            try
            {
                return this.employerDAO.Pagination(filters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployerDTO Save(EmployerDTO employerDTO)
        {
            try
            {
                return this.employerDAO.Save(employerDTO);
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
                return this.employerDAO.Update(employerDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
