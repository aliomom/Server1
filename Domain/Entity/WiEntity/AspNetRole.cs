using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Entity.WiEntity
{
    [DataContract]
    public  class AspNetRole
    {
      
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        [Required]
       
        public string Name { get; set; }
        [DataMember]
        private ICollection<AspNetUser> _users;
        public virtual ICollection<AspNetUser> AspNetUsers
        {
            get { return _users ?? (_users = new List<AspNetUser>()); }
            set { _users = value; }
        }
    }
}
