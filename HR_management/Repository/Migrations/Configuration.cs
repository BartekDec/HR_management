namespace Repository.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Models.HrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repository.Models.HrContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
           
            SeedEmpType(context);
            SeedSalary(context);
            SeedEmployee(context);

        }
        private void SeedRoles(HrContext context)
        {


        }
        private void SeedSalary(HrContext context)
        {
            var Salary = new Salary()
            {
                Id = 1,
                Amount = 2000.00m,
                Currency = "PLN",
                EmploymentTypeId = 1

            };
            context.Set<Salary>().AddOrUpdate(Salary);
            context.SaveChanges();
        }
        private void SeedEmpType(HrContext context)
        {
            var empType = new EmploymentType()
            {
                Id = 1,
                Tax = 0.30m,
                EmpTypeName = "Contract"

            };
            context.Set<EmploymentType>().AddOrUpdate(empType);
            context.SaveChanges();
        }
        private void SeedEmployee(HrContext context)
        {
            var employee = new Employee()
            {
                Id = 1,
                Name = "Dominika",
                Surname = "Guzik",
                PhoneNumber = "657890789",
                Email = "domiguzik@gmail.com",
                SalaryId = 1

            };
            context.Set<Employee>().AddOrUpdate(employee);
            context.SaveChanges();
        }


    }
}
