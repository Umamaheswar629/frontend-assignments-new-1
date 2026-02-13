using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopsDemo_Comparable_
{
    public class Class1 : IComparer<Emp>

    {
        public int Compare(Emp? x, Emp? y)
        {
            return x.EmpDept.CompareTo(y.EmpDept);
        }
    }
}
