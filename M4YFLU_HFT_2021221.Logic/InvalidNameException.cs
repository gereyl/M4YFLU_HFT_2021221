using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4YFLU_HFT_2021221.Logic
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string msg) : base(msg)
        {

        }

    }
}
