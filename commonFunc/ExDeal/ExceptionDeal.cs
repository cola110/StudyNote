using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.ExDeal
{
    public class ExceptionDeal
    {
        public int DevideAct()
        {
            try
            {
                int num1 = 0;
                int num2 = 10;
                return num2 / num1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // throw;
                return 0;
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}
