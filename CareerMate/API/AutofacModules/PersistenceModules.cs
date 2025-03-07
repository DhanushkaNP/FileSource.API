using Autofac;
using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using FileSource.Infrastructure.Persistence;

namespace FileSource.API.AutofacModules
{
    public class PersistenceModules : Module
    {     
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(SysAdminRepository).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<AppDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
