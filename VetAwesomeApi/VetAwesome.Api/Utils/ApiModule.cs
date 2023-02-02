using Autofac;

namespace VetAwesome.Api.Utils
{
    public class ApiModule : Module
    {
        private readonly IServiceCollection services;


        public ApiModule(IServiceCollection services)
        {
            this.services = services;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);


            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
        }
    }
}
