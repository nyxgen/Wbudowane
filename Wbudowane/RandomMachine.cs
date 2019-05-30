using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbudowane
{
    abstract class RandomMachine
    {
        static Random random = new Random();
        public static ref Random Random
        {
            get
            {
                return ref random;
            }
        }
    }
}
