using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_order_app_project
{
    class Company:Customer
    {
        public string Company_Name{  get; set; }   
        public string Company_Location {  get; set; }
        
        public void View_Company_Info()
        {
            Console.WriteLine($"Company Name is : {this.Company_Name}");
            Console.WriteLine($"Company Id Is : {this.Customer_Id}.");
            Console.WriteLine($"Company Phonge Is : {this.Customer_Phone}.");
            Console.WriteLine($"Company Address is : {this.Company_Location}");
            Console.WriteLine($"Customer Type Is : {this.Customer_Type}.");
        }
    }
}
