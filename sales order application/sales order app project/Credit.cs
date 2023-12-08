using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_order_app_project
{
    class Credit:Payment
    {
        public string Credit_Expire_Date {  get; set; } 
        public string Credit_Number {  get; set; }
        public string Credit_Type {  get; set; }
    }
}
