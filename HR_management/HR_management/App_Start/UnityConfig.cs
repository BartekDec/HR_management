using HR_management.ControllersComponents;
using HR_management.ControllersInterfaces;
using Microsoft.AspNet.Identity;
using Repository.DataAccess;
using Repository.Interfaces;
using Repository.Models;
using System;

using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
namespace HR_management
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<Repository.Interfaces.IRole, RoleAccess>(new PerRequestLifetimeManager());
            container.RegisterType<ISalary, SalaryAccess>(new PerRequestLifetimeManager());
            container.RegisterType<IPermission, PermissionAccess>(new PerRequestLifetimeManager());
            container.RegisterType < Repository.Interfaces.IUser, UserAccess>(new PerRequestLifetimeManager());
            container.RegisterType<IEmployee, EmployeeAccess>(new PerRequestLifetimeManager());
            container.RegisterType<IEmploymentType, EmploymentTypeAccess>(new PerRequestLifetimeManager());
            container.RegisterType<IHrContext, HrContext>(new PerRequestLifetimeManager());
            container.RegisterType<ISalaryComponents, SalaryComponents>(new PerRequestLifetimeManager());
            container.RegisterType<IEmployeeComponents, EmployeeComponents>(new PerRequestLifetimeManager());
            container.RegisterType<IEmploymentTypeComponents, EmploymentTypeComponents>(new PerRequestLifetimeManager());
            container.RegisterType<IRoleComponents, RoleComponents>(new PerRequestLifetimeManager());
            container.RegisterType<IPermissionComponents, PermissionComponents>(new PerRequestLifetimeManager());



        }
    }
}