using Domain;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInfra
{
    [DataContract]
    public class Test
    {
        ApplicationDbContext _context = new ApplicationDbContext("DefaultConnection");
      
        private IRepository<Test1> _test1;
        [DataMember]
        public IRepository<Test1> Test1Repository
        {
            get { return _test1 ?? (_test1 = new Repository<Test1>(_context)); }

        }



    }
}
