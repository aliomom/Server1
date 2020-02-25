using Domain;
using Domain.Entity.WiEntity;
using ServiceInfra.WIRepository.Interface;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceInfra.WIRepository
{
    internal class AspNetRoleRepository : Repository<AspNetRole>, IAspNetRoleRepository
    {
        internal AspNetRoleRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public AspNetRole FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<AspNetRole> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<AspNetRole> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
