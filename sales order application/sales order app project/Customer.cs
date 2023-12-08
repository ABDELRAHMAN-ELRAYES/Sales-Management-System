
using System.ComponentModel.Design;

namespace sales_order_app_project
{
    enum Customer_Operation
    {
        Add_Customer=1, 
        Edit_Customer=2, 
        Delete_Customer=3,
        Search_For_Customer= 4,
        View_All_Customers=5
    }
    class Customer:Customers_Operations
    {
        public int Customer_Id {  get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Type { get; set; }
         
        public bool Same_Customer(Customer customer)
        {
            return (this.Customer_Id == customer.Customer_Id);
        }
        
        private Customer_Operation Get_Customer_Selection_Operation()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Customer ");
            Console.WriteLine("2. Edit Customer");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. Search For Customer");

            int Select_Option;
            if (int.TryParse(Console.ReadLine(), out Select_Option))
            {
                if (Enum.IsDefined(typeof(Customer_Operation), Select_Option))
                {
                    return (Customer_Operation)Select_Option;
                }
            }
            Console.WriteLine("Invalid selection. Please try again.");
            return Get_Customer_Selection_Operation();
        }
        public void Customer_Operations(int Customer_Type)
        {
            Customer_Operation Info_Select = Get_Customer_Selection_Operation();

            Customer customer = this;
            switch (Info_Select)
            {
                case Customer_Operation.Add_Customer:
                    Add_Customer(customer);
                    break;
                case Customer_Operation.Edit_Customer:
                    Edit_Customer(customer, Customer_Type);
                    break;
                case Customer_Operation.Delete_Customer:
                    Delete_Customer(customer);
                    break;
                case Customer_Operation.Search_For_Customer:
                    Search_For_Customer(customer.Customer_Id,Customer_Type);
                    break;
            }
        }
    }
}
