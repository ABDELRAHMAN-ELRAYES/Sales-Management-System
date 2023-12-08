using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_order_app_project
{
    class Cash:Payment
    {
        public double Cash_Value;
        public Cash() { 
            Cash_Value = Payment_Amount;
        }
    }
}
