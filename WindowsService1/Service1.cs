using Autofac;
using Autofac.Integration.Wcf;
using Service;
using Service.Interface;
using ServiceInfra;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private static void EndPointIntilaize(Autofac.IContainer container, BasicHttpBinding bind)
        {
            Uri address = new Uri("http://localhost:8081/test/");
            ServiceHost host = new ServiceHost(typeof(Test1Service), address);
            host.AddServiceEndpoint(typeof(ITest1Service), bind, string.Empty);

            host.AddDependencyInjectionBehavior<ITest1Service>(container);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address });
            host.Open();

            Uri address2 = new Uri("http://localhost:8081/user/");
            ServiceHost host2 = new ServiceHost(typeof(UserService), address2);
            host2.AddServiceEndpoint(typeof(IUserService), bind, string.Empty);
            host2.AddDependencyInjectionBehavior<IUserService>(container);
            host2.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address2 });
            host2.Open();



            Uri address4 = new Uri("http://localhost:8081/RoleService/");
            ServiceHost host4 = new ServiceHost(typeof(RoleService), address4);
            host4.AddServiceEndpoint(typeof(IRoleService), bind, string.Empty);
            host4.AddDependencyInjectionBehavior<IRoleService>(container);
            host4.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address4 });
            host4.Open();




        }

        private static BasicHttpBinding BindInitalize()
        {
            var bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = int.MaxValue;
            bind.MaxBufferSize = int.MaxValue;
            bind.MaxReceivedMessageSize = int.MaxValue;
            bind.ReceiveTimeout = TimeSpan.MaxValue;
            bind.OpenTimeout = TimeSpan.MaxValue;
            bind.SendTimeout = TimeSpan.MaxValue;
            bind.TransferMode = TransferMode.Buffered;
            return bind;
        }

        private static ContainerBuilder GetRegesterType()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter(new TypedParameter(typeof(string), "DefaultConnection"));
            builder.RegisterType<Test1Service>().As<ITest1Service>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<Service.RoleService>().As<IRoleService>();
            return builder;
        }



        public Service1()
        {
            InitializeComponent();
            ContainerBuilder builder = GetRegesterType();
            using (var container = builder.Build())
            {
                BasicHttpBinding bind = BindInitalize();

                EndPointIntilaize(container, bind);


            }
        }

        protected override void OnStart(string[] args)
        {




        }

        protected override void OnStop()
        {
        }


    }
}
