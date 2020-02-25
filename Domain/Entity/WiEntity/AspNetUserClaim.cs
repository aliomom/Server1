using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Entity.WiEntity
{
    [DataContract]
    public  class AspNetUserClaim
    {
        private AspNetUser _user;

        [DataMember]
        public int Id { get; set; }

     
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public string ClaimType { get; set; }
        [DataMember]
        public string ClaimValue { get; set; }
        [DataMember]
        public virtual AspNetUser AspNetUser
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.Id;
            }
        }
    }
}