using Homework1.Data.UnitOfWork.Concrete;
using Homework1.Data;
using System.Security.Principal;
using Homework1.Data.Model;
using Homework1.Data.UnitOfWork.Abstract;
using Homework1.Data.Repository.Abstract;
using Homework1.Data.Repository.Concrete;

namespace Homework1.Web.StartupExtension
{
    public static class StartupExtension
    {
        public static void AddServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository<Staff>, GenericRepository<Staff>>();
        }
    }
}
