using Domain.Entity;
using ServiceInfra.WIRepository.Interface;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceInfra
{

    [ServiceContract]
  
        
    public interface IUnitOfWork
    {

        IAspNetUserLoginRepository AspNetUserLoginRepository { get; }
        IAspNetRoleRepository AspNetRoleRepository { get; }
        IAspNetUserRepository AspNetUserRepository { get; }


        [OperationContract]
        Test1 test(Test1 test);
        [OperationContract]
        void Dispose();
        [OperationContract]
        int SaveChanges();
        [OperationContract]
        void Add(Test1 test);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
       
      

    }
}