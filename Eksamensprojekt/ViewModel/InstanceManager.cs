using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class InstanceManager
    {
        private static InstanceManager instance;
        public static InstanceManager GetInstance()
        {
            if (instance == null)
            {
                instance = new InstanceManager();
            }
            return instance;
        }
        private InstanceManager()
        {

        }

    }
}
