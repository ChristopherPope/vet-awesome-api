using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Bll.Interfaces.RandomEntityMaker;
using VetAwesome.Bll.Interfaces.Services;
using VetAwesome.Bll.RandomDataMakers;
using VetAwesome.Bll.Services;
using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Persistence;

namespace VetAwesome.Bll.Utils
{
    public class BllModule : Module
    {
        private readonly IServiceCollection services;
        private readonly string? connectionString; // todo: why do we need cs passed in ctor?


        public BllModule(IServiceCollection services, string? connectionString)
        {
            this.services = services;
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterAutoMapper(builder);
            RegisterDbContext(builder);
            RegisterRandomDataMakers(builder);

            builder.RegisterType<AppointmentService>().As<IAppointmentService>().InstancePerLifetimeScope();
            builder.RegisterType<UsersService>().As<IUsersService>().InstancePerLifetimeScope();
            builder.RegisterType<SeedService>().As<ISeedService>().InstancePerLifetimeScope();
            builder.RegisterType<SeedService>().As<ISeedService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }

        private void RegisterRandomDataMakers(ContainerBuilder builder)
        {
            builder.RegisterType<RandomCustomerMaker>().As<IRandomCustomerMaker>().InstancePerLifetimeScope();
            builder.RegisterType<RandomNameMaker>().As<IRandomNameMaker>().InstancePerLifetimeScope();
            builder.RegisterType<RandomPetMaker>().As<IRandomPetMaker>().InstancePerLifetimeScope();
            builder.RegisterType<RandomPhoneNumberMaker>().As<IRandomPhoneNumberMaker>().InstancePerLifetimeScope();
            builder.RegisterType<RandomUserMaker>().As<IRandomUserMaker>().InstancePerLifetimeScope();
            builder.RegisterType<RandomAppointmentMaker>().As<IRandomAppointmentMaker>().InstancePerLifetimeScope();
        }

        private void RegisterDbContext(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var opt = new DbContextOptionsBuilder<VetDbContext>();
                opt.UseSqlServer(config.GetConnectionString("VetAwesomeDb"));

                return new VetDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }

        private void RegisterAutoMapper(ContainerBuilder builder)
        {
            builder.Register<AutoMapper.IConfigurationProvider>(ctx => new AutoMapper.MapperConfiguration(cfg => cfg.AddMaps(ThisAssembly))).SingleInstance();
            builder.Register<AutoMapper.IMapper>(ctx => new AutoMapper.Mapper(ctx.Resolve<AutoMapper.IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();
        }
    }
}
