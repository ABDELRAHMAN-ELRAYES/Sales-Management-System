using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_order_app_project
{
    class Customers_Operations
    {
        private static List<Customer> Customers;
        public Customers_Operations()
        {
            Customers = new List<Customer>();
        }
        protected void Add_Customer(Customer customer)
        {
            var CheckFound = false;
            foreach (Customer cust in Customers)
            {
                if (cust.Same_Customer(customer))
                {
                    Console.WriteLine("This Customer is Found ,You Can't able to Add him Again.");
                    CheckFound = true;
                    break;
                }
            }
            if (!CheckFound)
            {
                Customers.Add(customer);
                Console.WriteLine("Customer is added successfully.");
            }
        }
        protected void Edit_Customer(Customer customer,int Customer_Type)
        {
            var CheckFound = false;
            foreach (Customer cust in Customers)
            {
                if (cust.Same_Customer(customer))
                {
                    CheckFound = true;
                    break;
                }
            }
            if (CheckFound)
            {
                Edit_Customer_Options(customer,Customer_Type);
            }
            else
            {
                Console.WriteLine("This Customer is Not found ,Please Add the customer data Firstly and try again .");
            }
        }
        protected void Delete_Customer(Customer customer)
        {
            var CheckFound = false;
            foreach (Customer cust in Customers)
            {
                if (cust.Same_Customer(customer))
                {
                    Customers.Remove(cust);
                    CheckFound = true;
                    break;
                }
            }
            if (CheckFound)
            {
                Console.WriteLine("Customer is deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Customer Entered Is Not Found!");
            }

        }
        public void Search_For_Customer(int customer_id,int Customer_Type)
        {
            var CheckFound = false;
            foreach (Customer cust in Customers)
            {

                if (cust.Customer_Id==customer_id)
                {
                    CheckFound = true;

                    Console.WriteLine($"Customer Is Found.");
                    if (Customer_Type == 1)
                    {
                        Person person=(Person)cust;
                        person.View_Person_Info();
                        break;
                    }
                    else
                    {
                        Company company=(Company)cust;
                        company.View_Company_Info();
                    }
                    
                }
            }
            if (!CheckFound)
            {
                Console.WriteLine("Customer Entered Is Not Found!");
            }
        }
        private void Edit_Customer_Options(Customer customer,int Customer_Type) {
            Console.WriteLine("Select Option Number : ");
            Console.WriteLine("1. Edit Customer Id.");
            Console.WriteLine("2. Edit Customer Phone.");
            Console.WriteLine("3. Edit Customer Type.");
            Console.WriteLine("4. Edit Customer Name.");
            Console.WriteLine("5. Edit Customer Location.");
            int Option = int.Parse(Console.ReadLine());
            switch (Customer_Type)
            {
                case 1:
                    Person person = (Person)customer;
                    switch (Option)
                    {
                        case 1:
                            Console.Write("Enter the new ID");
                            int New_Customer_Id = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            person.Customer_Id = New_Customer_Id;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 2:
                            Console.WriteLine("Enter the new Phone Number : ");
                            string New_Customer_Phone = Console.ReadLine();
                            Console.WriteLine();
                            person.Customer_Phone = New_Customer_Phone;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 3:
                            Console.Write("Enter the new Type (Person/Company) : ");
                            string New_Customer_Type = Console.ReadLine();
                            Console.WriteLine();
                            person.Customer_Type = New_Customer_Type;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 4:
                            Console.Write("Enter the new Full Name");
                            string New_Customer_Name = Console.ReadLine();
                            Console.WriteLine();
                            person.Person_FullName = New_Customer_Name;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 5:
                            Console.WriteLine("Enter the new Address ");
                            string New_Customer_Address = Console.ReadLine();
                            person.Person_Billing_Address = New_Customer_Address;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            Edit_Customer_Options(customer, Customer_Type);
                            break;
                    }
                    break;
                case 2:

                    Company company= (Company)customer; 
                    switch (Option)
                    {
                        case 1:
                            Console.Write("Enter the new ID : ");
                            int New_Customer_Id = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            company.Customer_Id = New_Customer_Id;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 2:
                            Console.Write("Enter the new Phone Number : ");
                            string New_Customer_Phone = Console.ReadLine();
                            Console.WriteLine();
                            company.Customer_Phone = New_Customer_Phone;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 3:
                            Console.Write("Enter the new Type (Person/Company) : ");
                            string New_Customer_Type = Console.ReadLine();
                            Console.WriteLine();
                            company.Customer_Type = New_Customer_Type;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 4:
                            Console.Write("Enter the new Name");
                            string New_Customer_Name = Console.ReadLine();
                            Console.WriteLine();
                            company.Company_Name = New_Customer_Name;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        case 5:
                            Console.WriteLine("Enter the new Location ");
                            string New_Customer_Address = Console.ReadLine();
                            company.Company_Location = New_Customer_Address;
                            Console.WriteLine("Edit is Done successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            Edit_Customer_Options(customer, Customer_Type);
                            break;
                    }
                    break;
            }
        }
        public void View_All_Customers()
        {
            int Count = 1;
            Console.WriteLine("Our Customers Are :");
            Console.WriteLine();

            foreach (Customer cust in Customers_Operations.Customers)
            {
                if (cust.Customer_Type == "Person")
                {
                    Person person = (Person)cust;
                    person.View_Person_Info();
                    Console.WriteLine();
                }
                else
                {
                    Company company = (Company)cust;
                    company.View_Company_Info();
                    Console.WriteLine();
                }
            }
        } 
    }
}
