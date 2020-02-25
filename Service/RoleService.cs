using Domain.Entity.WiEntity;
using Service.Interface;
using ServiceInfra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class RoleService : IRoleService

    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IRoleStore<IdentityRole, Guid> Members
        public System.Threading.Tasks.Task CreateAsync(AspNetRole role)
        {
            if (role == null)  throw new ArgumentNullException("role");
              

            var r = getRole(role);

            _unitOfWork.AspNetRoleRepository.Add(r);
            return _unitOfWork.SaveChangesAsync();
        }  

        public System.Threading.Tasks.Task DeleteAsync(AspNetRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = getRole(role);

            _unitOfWork.AspNetRoleRepository.Remove(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task<AspNetRole> FindByIdAsync(Guid roleId)
        {
            var role = _unitOfWork.AspNetRoleRepository.FindById(roleId);
            return Task.FromResult<AspNetRole>(getIdentityRole(role));
        }

        public System.Threading.Tasks.Task<AspNetRole> FindByNameAsync(string roleName)
        {
            var role = _unitOfWork.AspNetRoleRepository.FindByName(roleName);
            return Task.FromResult<AspNetRole>(getIdentityRole(role));
        }

        public System.Threading.Tasks.Task UpdateAsync(AspNetRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            var r = getRole(role);
            _unitOfWork.AspNetRoleRepository.Update(r);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region THIS IS FOR"""" IQueryableRoleStore<IdentityRole, Guid> Members
        public List<AspNetRole>Roles()
        {
          
                return _unitOfWork.AspNetRoleRepository.GetAll();
                   
            
        }
        #endregion

        #region Private Methods
        private AspNetRole getRole(AspNetRole identityRole)
        {
            if (identityRole == null)
                return null;
            return new AspNetRole
            {
                Id = identityRole.Id,
                Name = identityRole.Name
            };
        }

        private AspNetRole getIdentityRole(AspNetRole role)
        {
            if (role == null)
                return null;
            return new AspNetRole
            {
                Id = role.Id,
                Name = role.Name
            };
        }
        #endregion
    }
}
