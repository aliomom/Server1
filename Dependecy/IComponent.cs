using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dependecy.ComponentLoader;

namespace Dependecy
{
  /// <summary>
        /// Register underlying types with unity.
        /// </summary>
        public interface IComponent
        {
            void SetUp(IRegisterComponent registerComponent);
        }
   
}
