using System.Threading;
using System.Threading.Tasks;
using Domain.Entity.WiEntity;

namespace ServiceInfra.WIRepository.Interface
{
   public  interface IAspNetRoleRepository : IRepository<AspNetRole>
    {
        AspNetRole FindByName(string roleName);
        Task<AspNetRole> FindByNameAsync(CancellationToken cancellationToken, string roleName);
        Task<AspNetRole> FindByNameAsync(string roleName);
    }
}