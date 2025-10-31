using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyLibrary.Models
{
    public class TechnologyException : Exception
    {
        public TechnologyException(string errMsg) : base(errMsg) { }
    }
}
