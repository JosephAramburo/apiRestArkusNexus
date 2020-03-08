﻿using DAO.Config;
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

        public EmployerDTO GetById(int id)
        {
            try
            {
                return this.employerDomainObject.GetById(id);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}