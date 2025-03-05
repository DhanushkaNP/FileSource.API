using Autofac;
using FileSource.Infrastructure.Persistence;

namespace FileSource.API.AutofacModules
{
    public class PersistenceModules : Module
    {
        // ToDo
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterAssemblyTypes(typeof(SysAdminRepository).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<AppDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
