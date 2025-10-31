using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    public class TrainingException : Exception
    {
        public TrainingException(string errMsg) : base(errMsg) { }
    }
}
