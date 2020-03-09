using Common.Config;
using Common.DTO;
using Common.Interfaces;
using DomainObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class EmployerManager : IEmployer
    {
        private readonly EmployerDomainObject employerDomainObject;

        public EmployerManager(DataBaseContext dataBaseContext)
        {
            this.employerDomainObject = new EmployerDomainObject(dataBaseContext);            
        }

        public EmployerFiltersResponse GetByFilters(EmployerFiltersRequest employerFiltersRequest)
        {
            try
            {
                return this.employerDomainObject.GetByFilters(employerFiltersRequest);
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
                return this.employerDomainObject.GetById(id);
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
                return this.employerDomainObject.Delete(id);
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
                return this.employerDomainObject.Pagination(filters);
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
                return this.employerDomainObject.Save(employerDTO);
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
                return this.employerDomainObject.Save(employerDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
