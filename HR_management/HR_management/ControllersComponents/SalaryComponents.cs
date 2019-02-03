using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Interfaces;
using HR_management.ControllersInterfaces;

namespace HR_management.ControllersComponents
{
    public class SalaryComponents : Controller, ISalaryController
    {
        private readonly ISalary _Isalary;
        private readonly IHrContext _context;

        public SalaryComponents(ISalary salary, IHrContext context)
        {
            _Isalary = salary;
            _context = context;
        }
        public

    }
}