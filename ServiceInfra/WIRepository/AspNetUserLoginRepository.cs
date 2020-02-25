using Domain;
using Domain.Entity.WiEntity;
using ServiceInfra.WIRepository.Interface;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceInfra.WIRepository
{
    internal class AspNetUserLoginRepository : Repository<AspNetUserLogin>,IAspNetUserLoginRepository
    {
        internal AspNetUserLoginRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public AspNetUserLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<AspNetUserLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<AspNetUserLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
        }
    }
}
