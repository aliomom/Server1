using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Wcf;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service;
using Service.Interface;
using ServiceInfra;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private static IContainer Container { get; set; }
        private readonly ILogger<Worker> _logger;



        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            Assembly asm = Assembly.ReflectionOnlyLoadFrom(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.ServiceModel.dll");
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {




            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter(new TypedParameter(typeof(string), "DefaultConnection"));
            builder.RegisterType<Test1Service>().As<ITest1Service>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<Service.RoleService>().As<IRoleService>();
            var bind = new BasicHttpBinding
            {
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                OpenTimeout = TimeSpan.MaxValue,
                SendTimeout = TimeSpan.MaxValue,
                TransferMode = TransferMode.Buffered
            };
            using (var container = builder.Build())
            {
                Uri address = new Uri("http://localhost:8081/test/");
                ServiceHost host = new ServiceHost(typeof(Test1Service), address);
                host.AddServiceEndpoint(typeof(ITest1Service), bind, string.Empty);

                host.AddDependencyInjectionBehavior<ITest1Service>(container);
                host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address });
                host.Open();
                _logger.LogInformation("The host of " + host.Description.Name.ToString() + " has been opened.");

                Uri address2 = new Uri("http://localhost:8081/user/");
                ServiceHost host2 = new ServiceHost(typeof(UserService), address2);
                host2.AddServiceEndpoint(typeof(IUserService), bind, string.Empty);
                host2.AddDependencyInjectionBehavior<IUserService>(container);
                host2.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address2 });
                host2.Open();
                _logger.LogInformation("The host of " + host2.Description.Name.ToString() + " has been opened.");



                Uri address4 = new Uri("http://localhost:8081/RoleService/");
                ServiceHost host4 = new ServiceHost(typeof(RoleService), address4);
                host4.AddServiceEndpoint(typeof(IRoleService), bind, string.Empty);
                host4.AddDependencyInjectionBehavior<IRoleService>(container);
                host4.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address4 });
                host4.Open();
                _logger.LogInformation("The host of " + host4.Description.Name.ToString() + " has been opened.");
                return ExecuteAsync(stoppingToken);



            }



        }
    }
}
