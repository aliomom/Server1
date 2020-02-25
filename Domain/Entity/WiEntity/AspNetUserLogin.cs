using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Domain.Entity.WiEntity
{[DataContract]
    public  class AspNetUserLogin
    {
        private AspNetUser _user;

        [DataMember]
      

        public string LoginProvider { get; set; }
        [DataMember]
      
        

        public string ProviderKey { get; set; }
        [DataMember]
       
      
        public Guid UserId { get; set; }
        [DataMember]
        public virtual AspNetUser AspNetUser
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.Id;
            }
        }
    }
}