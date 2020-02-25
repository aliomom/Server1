using Domain.Configuration;
using Domain.Entity;
using Domain.Entity.WiEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(string nameOrConnectionString) :base(nameOrConnectionString = "DefaultConnection")
        {


        }

        public ApplicationDbContext():base("DefaultConnection")
        {

        }
      
        private IDbSet<Test1> Test1 { get; set;  }

        public virtual IDbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual IDbSet<AspNetUser> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new Test1Configuration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new LoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
        }

    }
}
