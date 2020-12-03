using FormValidation.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FormValidation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserServices, UserServices>();
            container.RegisterType<ICreateUser, CreateUser>();
            container.RegisterType<IReadData, ReadData>();
            container.RegisterType<IEditData, EditData>();
            container.RegisterType<IDeleteData, DeleteData>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}