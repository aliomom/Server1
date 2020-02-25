using System;
using System.Collections.Generic;
using Domain.Entity.WiEntity;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service.Interface
{
    [ServiceContract]
    public interface IUserService
    {[OperationContract]
        Guid Add(AspNetUser dto);
        [OperationContract]
        bool Delete(Guid id);
        [OperationContract]
        bool Edit(AspNetUser dto);
        [OperationContract]
        void editForAdm(Guid id, string fullname, string userName);
        [OperationContract]
        bool Exists(Guid id);
        [OperationContract]
        List<AspNetUser> GetAll();
        [OperationContract]
        AspNetUser GetById(Guid id);
        [OperationContract]
        List<AspNetUser> GetUsersByRole(string role);
        [OperationContract]

        bool HasRole(Guid id, string role);
        [OperationContract]
        bool IsEmailUnique(string email);
        [OperationContract]
        AspNetUser GetByName(string name);
        [OperationContract]
        AspNetUserLogin GetByProviderAndKey(string loginProvider, string providerKey);
        [OperationContract]
        AspNetRole GetRolebyName(String name);
        [OperationContract]
        AspNetUser GetByEmail(string mail);
        //[OperationContract]
        //Task<IList<string>> GetRolesAsync(AspNetUser user);

    }
}