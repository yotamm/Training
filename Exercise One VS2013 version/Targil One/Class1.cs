using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil_One
{
    public class NoLogDefinedException : Exception
    {
        public NoLogDefinedException(string fileName)
            : base(string.Format("The log file: {0} is not defined", fileName))
        {
            
        }
    }
}
