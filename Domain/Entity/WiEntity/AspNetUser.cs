using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Entity.WiEntity
{[DataContract ]
    public  class AspNetUser
    {

       

        [DataMember]
        public Guid Id { get; set; }

        [StringLength(256)]
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool EmailConfirmed { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public string SecurityStamp { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public bool PhoneNumberConfirmed { get; set; }
        [DataMember]
        public bool TwoFactorEnabled { get; set; }
        [DataMember]
        public DateTime? LockoutEndDateUtc { get; set; }
        [DataMember]
        public bool LockoutEnabled { get; set; }
        [DataMember]
        public int AccessFailedCount { get; set; }
        [DataMember]
        [Required]
       
        public string UserName { get; set; }
        [DataMember]
        public string FullName { get; set; }



        private ICollection<AspNetUserClaim> _claims;
        private ICollection<AspNetUserLogin> _externalLogins;
        private ICollection<AspNetRole> _roles;
        [DataMember]
       
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims {
            get { return _claims ?? (_claims = new List<AspNetUserClaim>()); }
            set { _claims = value; }
        }
        [DataMember]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<AspNetUserLogin>());
            }
            set { _externalLogins = value; }
        }
        [DataMember]
        public virtual ICollection<AspNetRole> AspNetRoles
        {
            get { return _roles ?? (_roles = new List<AspNetRole>()); }
            set { _roles = value; }
        }
    }
}