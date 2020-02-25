using Domain.Entity.WiEntity;
using Service.Interface;
using ServiceInfra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AspNetUser GetByEmail(string mail)
        {

            return  _unitOfWork.AspNetUserRepository.FindByEmail(mail);

        }

        public AspNetUserLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            var model = _unitOfWork.AspNetUserLoginRepository.GetByProviderAndKey(loginProvider, providerKey);
            return model;
        }

        public AspNetRole GetRolebyName(String name)
        {
            return _unitOfWork.AspNetRoleRepository.FindByName(name);


        }
        public Guid Add(AspNetUser dto)
        {
            
            _unitOfWork.AspNetUserRepository.Add(dto);
            _unitOfWork.SaveChanges();
            return dto.Id;
        }
        public void editForAdm(Guid id, string fullname, string userName)
        {
            var user = _unitOfWork.AspNetUserRepository.FindById(id);
            user.UserName = userName;
            user.FullName = fullname;
            _unitOfWork.AspNetUserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }
        public bool Edit(AspNetUser dto)
        {
          
            if (dto == null)
                return false;
            _unitOfWork.AspNetUserRepository.Update(dto);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            AspNetUser user = _unitOfWork.AspNetUserRepository.FindById(id);
            if (user == null)
                return false;
            _unitOfWork.AspNetUserRepository.Remove(user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public AspNetUser GetById(Guid id)
        {
            var model = _unitOfWork.AspNetUserRepository.FindById(id);
            return model;
        }
        public AspNetUser GetByName(string name)
        {
            var model = _unitOfWork.AspNetUserRepository.FindByUserName(name);
            return model;
        }
        public List<AspNetUser> GetAll()
        {
            return _unitOfWork.AspNetUserRepository.GetAll();
        }
        public bool HasRole(Guid id, string role)
        {
            return (GetById(id).AspNetRoles.Where<AspNetRole>(x => x.Name == role) == null) ? true : false;
        }
        public bool Exists(Guid id)
        {
            return GetById(id) == null ? false : true;
        }


        public List<AspNetUser> GetUsersByRole(string role)
        {
            return GetAll().AsEnumerable().Where(u => HasRole(u.Id, role)).ToList();
        }

        public bool IsEmailUnique(string email)
        {
            return _unitOfWork.AspNetUserRepository.FindByEmail(email.ToLower()) == null;
        }

        //public Task<IList<string>> GetRolesAsync(AspNetUser user)
        //{
        //    if (user == null)
        //        throw new ArgumentNullException("user");

        //    var u = _unitOfWork.AspNetUserRepository.FindById(user.Id);
        //    if (u == null)
        //        throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

        //    return Task.FromResult<IList<string>>(u.AspNetRoles.Select(x => x.Name).ToList());
        //}
    }
}
