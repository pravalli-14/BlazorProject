using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary.Models
{
    public class TrainerException : Exception
    {
        public TrainerException(string errMsg) : base(errMsg) { }
    }
}
