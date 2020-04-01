using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Tool_Standalone
{
    public static class Utilities
    {
        public class Double<_Ty>{

            public _Ty A { get; set; }
            public _Ty B { get; set; }
            public Double(_Ty a, _Ty b)
            {
                A = a;
                B = b;
            }
        }

    }
}
