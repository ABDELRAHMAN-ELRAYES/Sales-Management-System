using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_order_app_project
{
    class Person:Customer
    {
        public string Person_Billing_Address{ get; set; }
        public string Person_FullName { get; set; }
        
        public void View_Person_Info()
        {
            Console.WriteLine($"Person Name is : {this.Person_FullName}");
            Console.WriteLine($"Person Id Is : {this.Customer_Id}.");
            Console.WriteLine($"Person Phonge Is : {this.Customer_Phone}.");
            Console.WriteLine($"Person Address is : {this.Person_Billing_Address}");
            Console.WriteLine($"Customer Type Is : {this.Customer_Type}.");
        }

    }
}
