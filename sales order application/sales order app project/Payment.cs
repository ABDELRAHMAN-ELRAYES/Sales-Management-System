using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_order_app_project
{
    class Payment
    {
        public int Payment_Id;
        public DateTime Payment_Date;
        public double Payment_Amount;
        public string Payment_Type;
        public double Pay(OrderItem orderitem) 
        {
            Payment_Amount=orderitem.Sale_Price* orderitem.Sale_Quantity;
            return Payment_Amount; 
        }
    }
}
