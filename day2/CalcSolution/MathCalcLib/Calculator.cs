using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCalcLib
{
    public class Calculator
    {

        public int CubeEvenNo(int no)
        {
            if (no % 2 != 0)
            {
                throw new ArgumentException("The number is not even.");
            }
            return no * no * no;
        }
    }
}
