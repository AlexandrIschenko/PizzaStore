using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Validators
{
    public static class InputValidation
    {
        public static double ReturnDouble(string num)
        {            
            bool check = Double.TryParse(num, out double x);
            if (!check) x = double.MinValue;
            return x;
        }

        public static bool UserChosePizza(string mathOperator)
        {
            List<string> operatorWithSecondArguments = new List<string> { "1", "2", "3" };
            bool check = true;
            if (operatorWithSecondArguments.Contains(mathOperator))
            {
                check = true;
            }
            else check = false;
            return check;
        }

    }
}
