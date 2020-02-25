using ServiceInfra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
  
        [Export(typeof(IComponent))]
        public class DependencyResolver : IComponent
        {
            public void SetUp(IRegisterComponent registerComponent)
            {
                registerComponent.RegisterTypeWithInjectedConstructor<IUnitOfWork, UnitOfWork>("Server1");


            }

           
        }
   
}
