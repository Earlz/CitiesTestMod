using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMod
{
    class ModMain: IUserMod
    {
        public string Name 
        {
            get { return "Your mod name here"; }
        }

        public string Description 
        {
            get { return "Your mod description here"; }
			
        }
    }
}
