using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity.WiEntity;
using System.ServiceModel;
using System.Collections.Generic;

namespace Service.Interface
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        List<AspNetRole> Roles();
        [OperationContract]
        Task CreateAsync(AspNetRole role);
        [OperationContract]
        Task DeleteAsync(AspNetRole role);
        [OperationContract]
        void Dispose();
        [OperationContract]
        Task<AspNetRole> FindByIdAsync(Guid roleId);
        [OperationContract]
        Task<AspNetRole> FindByNameAsync(string roleName);
        [OperationContract]
        Task UpdateAsync(AspNetRole role);
    }
}