using System.Threading;
using System.Threading.Tasks;
using Domain.Entity.WiEntity;

namespace ServiceInfra.WIRepository.Interface
{
    public interface IAspNetUserRepository: IRepository<AspNetUser>
    {
        AspNetUser FindByEmail(string email);
        Task<AspNetUser> FindByEmailAsync(CancellationToken cancellationToken, string email);
        Task<AspNetUser> FindByEmailAsync(string email);
        AspNetUser FindByUserName(string username);
        Task<AspNetUser> FindByUserNameAsync(CancellationToken cancellationToken, string username);
        Task<AspNetUser> FindByUserNameAsync(string username);
    }
}