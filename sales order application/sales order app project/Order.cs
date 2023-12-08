using System.Runtime.InteropServices;

namespace sales_order_app_project
{
    enum Order_Info_Options
    {
        Order_ID = 1,
        Sale_Price = 2,
        Sale_Quantity = 3,
        Order_Number = 4
    }
    class Order
    {
        public List<OrderItem> Orders;
        public double Total_Price_Of_Orders;

        public Order()
        {
            Orders = new List<OrderItem>();
        }
        public void Create_Order(OrderItem orderitem, int productid, int Order_Quantity)
        {
            bool Check_Stock_And_Quantity = false, Check_If_Found_In_Orders = false;

            
            foreach (OrderItem item in this.Orders)
            {
                if (item.Order_ID == orderitem.Order_ID)
                {
                    Check_If_Found_In_Orders = true;

                    if (item.Check_Product_Existance_And_Quantitiy(productid, Order_Quantity))
                    {
                        Check_Stock_And_Quantity = true;
                        break;
                    }

                }
            }
            if (Check_If_Found_In_Orders)
            {
                Console.WriteLine("Order Item is already founded in orders list, Please select to update on it .");
            }
            else
            {
                double ProductPrice = 0;
                foreach (var product in Stock.Product_In_Stock)
                {
                    if(product.Product_ID == productid)
                    {
                        ProductPrice = product.Product_Price;
                        break;
                    }
                }
                Random random = new Random();
                orderitem.Sale_Price = Order_Quantity * ProductPrice;
                orderitem.Order_Number = random.Next(1, 100001);
                orderitem.Order_date = DateTime.Now;
                orderitem.Order_Status = "NEW";
                this.Orders.Add(orderitem);
                Console.WriteLine("Order created successfully .");
            }

        }
        public void Update_Order_status(int orderitem_ID)
        {
            bool Check_If_Found_In_Orders = false;
            foreach (OrderItem item in Orders)
            {
                if (item.Order_ID == orderitem_ID)
                {
                    Check_If_Found_In_Orders = true;
                    item.Select_Order_Status();
                }
            }
            if (!Check_If_Found_In_Orders)
                Console.WriteLine("Order Item is not founded in orders list, Please select to check the Information for the Order Item .");
        }

        public void Edit_Order(int orderitem_ID)
        {
            bool Check_If_Found_In_Orders = false;
            foreach (OrderItem item in Orders)
            {
                if (item.Order_ID == orderitem_ID)
                {
                    Check_If_Found_In_Orders = true;
                    Get_Operation_for_Edit_Order(item);
                    break;
                }
            }
            if (!Check_If_Found_In_Orders)
            {
                Console.WriteLine("Order Item is not founded in orders list, Please select to check the Information for the Order Item .");
            }

        }
        private Order_Info_Options Get_Order_Info_Operation()
        {
            Console.WriteLine("Select an option to change:");
            Console.WriteLine("1. Order ID");
            Console.WriteLine("2. Sale Price");
            Console.WriteLine("3. Sale Quantity");
            Console.WriteLine("4. Order Number");

            int Select_Option;
            if (int.TryParse(Console.ReadLine(), out Select_Option))
            {
                if (Enum.IsDefined(typeof(Order_Info_Options), Select_Option))
                {
                    return (Order_Info_Options)Select_Option;
                }
            }
            Console.WriteLine("Invalid selection. Please try again.");
            return Get_Order_Info_Operation();
        }
        private void Get_Operation_for_Edit_Order(OrderItem orderitem)
        {
            Order_Info_Options Info_Select = Get_Order_Info_Operation();
            switch (Info_Select)
            {
                case Order_Info_Options.Order_ID:
                    Console.Write("Enter the new ID :");
                    orderitem.Order_ID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Order Id has been edited successfully.");
                    break;
                case Order_Info_Options.Sale_Price:
                    Console.Write("Enter the new Price :");
                    orderitem.Sale_Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Order Price has been edited successfully.");
                    break;
                case Order_Info_Options.Order_Number:
                    Console.Write("Enter the new Number:");
                    orderitem.Order_Number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Order Number has been edited successfully.");
                    break;
                case Order_Info_Options.Sale_Quantity:
                    Console.Write("Enter the new Quantity :");
                    orderitem.Sale_Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Order Quantity has been edited successfully.");
                    break;
            }
        }
        public void View_all_orders()
        {
            int i = 1;
            foreach (OrderItem orderitem in this.Orders)
            {
                Console.WriteLine($"The info of order {i}");
                Console.WriteLine();
                Console.WriteLine($"The Order {orderitem.Order_ID}");
                Console.WriteLine($"The Order {orderitem.Sale_Price}");
                Console.WriteLine($"The Order {orderitem.Sale_Quantity}");
                Console.WriteLine($"The Order {orderitem.Order_date}");
                Console.WriteLine($"The Order {orderitem.Order_Number}");
                Console.WriteLine($"The Order {orderitem.Order_Status}");
                Console.WriteLine();

                Console.WriteLine("<>---------------------------------------------------------------------------------<>");
            }
        }
    }
}

