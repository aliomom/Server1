using System.Threading;
using System.Threading.Tasks;
using Domain.Entity.WiEntity;

namespace ServiceInfra.WIRepository.Interface
{
    public interface IAspNetUserLoginRepository : IRepository<AspNetUserLogin>
    {
        AspNetUserLogin GetByProviderAndKey(string loginProvider, string providerKey);
        Task<AspNetUserLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey);
        Task<AspNetUserLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
    }
}