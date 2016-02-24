using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp.L09
{
    public class L09_01
    {
        // Expression

        public void GetExpression()
        {
            Expression args1 = Expression.Constant(11);
            Expression args2 = Expression.Constant(13);

            var result = Expression.Add(args1, args2);
            Trace.WriteLine(result);
        }
    }
}
