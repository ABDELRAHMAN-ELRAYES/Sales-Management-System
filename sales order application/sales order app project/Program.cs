namespace sales_order_app_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Customers_Operations customers = new Customers_Operations();
            Order orders=new Order();
            Transaction transaction=new Transaction();

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Data Entry ");
            Console.WriteLine("2. Sales Process");
            Console.WriteLine("3. View");            

            Console.Write("Enter the Number of option Selected : ");
            int Selected = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (Selected)
            {
                case 1:
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Customer ");
                    Console.WriteLine("2. Product");


                    Console.Write("Enter the Number of option Selected : ");
                    int First_Option_Selected = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch (First_Option_Selected)
                    {
                        case 1:
                            Customer_Selected_Option();
                            break;
                        case 2:
                            Product_Selected_Option(stock);
                            break;
                        default:
                            Console.WriteLine("Invalid Selection.\nServer Timed Out. Please try again.");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Add Transaction ");
                    Console.WriteLine("2. Update Order");
                    Console.WriteLine("3. Pay Order");

                    Console.Write("Enter the Number of option Selected : ");
                    int Second_Option_Selected = int.Parse(Console.ReadLine());
                    switch (Second_Option_Selected)
                    {
                        case 1:
                            Console.WriteLine("Select an option:");
                            Console.WriteLine("1. Make Order");
                            Console.WriteLine("2. Edit order");

                            Console.Write("Enter the Number of option Selected : ");
                            int First_Second_Option_Selected = int.Parse(Console.ReadLine());
                            switch (First_Second_Option_Selected)
                            {
                                case 1:
                                    Add_order(orders);
                                    break;
                                case 2:
                                    Console.Write("Enter the order ID you want to Edit:");
                                    int OrderId=int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    orders.Edit_Order(OrderId);
                                    break;
                                default:
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    break;

                            }
                            break;
                        case 2:
                            Console.WriteLine("Select an option:");
                            Console.WriteLine("1. Update Order Quantity");
                            Console.WriteLine("2. Update Order Status");

                            Console.Write("Enter the Number of option Selected : ");
                            int second_Second_Option_Selected = int.Parse(Console.ReadLine());
                            Console.Write("Enter the ID of the order wanted to update :");
                            int order_id=int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            switch (second_Second_Option_Selected)
                            {
                                case 1:
                                    
                                    foreach(OrderItem item in orders.Orders)
                                    {
                                        if(item.Order_ID == order_id)
                                        {
                                            Console.WriteLine("Select an option:");
                                            Console.WriteLine("1. Reduce Quantity");
                                            Console.WriteLine("2. Increase Quantity");

                                            Console.Write("Enter the Number of option Selected : ");
                                            int First_second_Second_Option_Selected = int.Parse(Console.ReadLine());
                                            switch (First_second_Second_Option_Selected) { 
                                                case 1:
                                                    Console.Write("Enter the Quantity you want to Reduce :");
                                                    int Quantity_Reduced=int.Parse(Console.ReadLine());
                                                    item.Update_Quantity(order_id, Quantity_Reduced, 1);
                                                    break;
                                                case 2:
                                                    Console.Write("Enter the Quantity you want to Increase :");
                                                    int Quantity_Increased = int.Parse(Console.ReadLine());
                                                    item.Update_Quantity(order_id, Quantity_Increased, 2);
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid selection. Please try again.");
                                                    break;
                                            }
                                            
                                        }
                                    }
                                    break;
                                case 2:
                                    foreach (OrderItem item in orders.Orders)
                                    {
                                        if (item.Order_ID == order_id)
                                        {
                                            Console.WriteLine("Select an option to update the order Status to:");
                                            Console.WriteLine("1. Hold Order ");
                                            Console.WriteLine("2. Paid Order ");
                                            Console.WriteLine("3. Canceled Order ");
                                            Console.Write("Enter the Number of option Selected : ");
                                            int second_second_Second_Option_Selected = int.Parse(Console.ReadLine());
                                            switch (second_second_Second_Option_Selected)
                                            {
                                                case 1:
                                                    item.Order_Status = "Hold";
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Please,Check out the order to make it will be paid.");
                                                    break;
                                                case 3:
                                                    orders.Orders.Remove(item);
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid selection. Please try again.");
                                                    break;

                                            }
                                            Console.WriteLine("Status has been updated successfully.");
                                            break;
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    break;

                            }
                            break;
                        case 3:
                            Console.Write("Enter the Order ID you want to pay :");
                            int orderid=int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            bool check_if_found = false;
                            foreach(OrderItem orderitem in orders.Orders)
                            {
                                if (orderitem.Order_ID == orderid)
                                {

                                    transaction.Get_Order_Payment_Optoin(orderitem, orders);
                                    check_if_found = true;
                                    break;

                                }
                            }
                            if (!check_if_found)
                            {
                                Console.WriteLine("Order is not found in orders or Order ID is not correct.");
                                break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Selection.\nServer Timed Out. Please try again.");
                            break;

                    }
                    break;
                case 3:
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. All Customers ");
                    Console.WriteLine("2. All Orders");
                    Console.WriteLine("3. All Payments");
                    Console.WriteLine("4. All Products in stock");

                    Console.Write("Enter the Number of option Selected : ");
                    int Third_Option_Selected = int.Parse(Console.ReadLine());
                    switch(Third_Option_Selected)
                    {
                        case 1:
                            customers.View_All_Customers();
                            break;
                        case 2:
                            orders.View_all_orders();
                            break;
                        case 3:
                            transaction.Print_Payment_Transactions();
                            break;
                        case 4:
                            stock.View_all_Products();
                            break;
                        default:
                            Console.WriteLine("Invalid Selection.\nServer Timed Out. Please try again.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Selection.\nServer Timed Out. Please try again.");
                    break;
            }
        }
        private static void Customer_Selected_Option()
        {
            switch (Get_Customer_Type())
            {
                case 1:
                    Person person= new Person();
                    person.Customer_Type = "Person";
                    Console.Write("Enter the Person ID : ");
                    person.Customer_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter the Person Full Name : ");
                    person.Person_FullName = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter the Person Phone Number : ");
                    person.Customer_Phone = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter the Person Address : ");
                    person.Person_Billing_Address = Console.ReadLine();
                    Console.WriteLine();
                    person.Customer_Operations(1);
                    break;
                case 2:
                    Company company = new Company();
                    company.Customer_Type = "Company";
                    Console.Write("Enter the Company ID : ");
                    company.Customer_Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Company Full Name : ");
                    company.Company_Name = Console.ReadLine();
                    Console.Write("Enter the Company Phone Number : ");
                    company.Customer_Phone = Console.ReadLine();
                    Console.Write("Enter the Company Location : ");
                    company.Company_Location = Console.ReadLine();
                    company.Customer_Operations(2);
                    break;
            }  
        }

        private static int Get_Customer_Type()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Person ");
            Console.WriteLine("2. Company");

            Console.Write("Enter the Number of option Selected : ");
            int Second_Sption_Selected = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (Second_Sption_Selected)
            {
                case 1:
                    return Second_Sption_Selected;
                    break;
                case 2:
                    return Second_Sption_Selected;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    return Get_Customer_Type();
                    break;
            }

        }
        private static void Product_Selected_Option(Stock stock)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1.Add Product");
            Console.WriteLine("2.Delete Product");
            Console.WriteLine("3.Update Product");
            Console.WriteLine("4.Search for Product");
            Console.WriteLine();
            Console.Write("Enter the Number of operation Selected : ");
            int Option_Selected = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (Option_Selected)
            {
                case 1:
                    Console.Write("Enter the Number of different Products you want to Add: ");
                    int Number_Of_Product_To_Add = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Add_Product(stock,Number_Of_Product_To_Add);
                    break;
                case 2:
                    Console.Write("Enter the product Id which you want to delete :");
                    int productID=int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    stock.Delete_Stock(productID);
                    break;
                case 3:
                    Console.Write("Enter the product Id which you want to update :");
                    int ProductID = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    stock.Update_Stock(ProductID);
                    break;
                case 4:
                    Console.Write("Enter the product Id which you want to update :");
                    int productid = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    stock.Search_For_Product(productid);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    Console.WriteLine();
                    Product_Selected_Option(stock);
                    break;

            }
        }
        
        private static void Add_Product(Stock stock,int Number_Of_Products_To_Add)
        {
            

            for (int i = 1; i <= Number_Of_Products_To_Add; i++)
            {
                if (Number_Of_Products_To_Add > 1)
                {
                    Console.WriteLine($"Enter the Information of Product {i}");

                }
                Console.WriteLine();
                Product Product_obj = new Product();
                Console.Write("Enter Product Id: ");
                Product_obj.Product_ID= int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter Product Number: ");
                Product_obj.Product_Number = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter Product Name: ");
                Product_obj.Product_Name = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter Product Price: ");
                Product_obj.Product_Price = double.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter Product Type: ");
                Product_obj.Product_Type = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter Product Quantity: ");
                Product_obj.Product_Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine();

                
                stock.Add_Stock(Product_obj, Product_obj.Product_Quantity);


            }

        }
        private static void Add_order(Order orders)
        {
 
                OrderItem orderitem = new OrderItem();
                Console.Write("Enter Product Id: ");
                orderitem.Order_ID = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter Product Quantity: ");
                int OrderQuantity = int.Parse(Console.ReadLine());
                Console.WriteLine();
                orders.Create_Order(orderitem,orderitem.Order_ID, OrderQuantity);

        }
        
    }
       
}
    