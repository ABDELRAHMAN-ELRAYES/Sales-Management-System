
namespace sales_order_app_project
{
    class Transaction
    {
        public static List<Payment>Customer_Transactions;
        public DateTime Transaction_Date;
        public Credit credit=new Credit();
        public Cash cash=new Cash();
        public Check check=new Check();
        public Transaction()
        {
            Customer_Transactions = new List<Payment>();
        }
        public void Get_Order(Order order,OrderItem orderitem)
        {
            bool Check_If_Found_In_Orders = false;
            foreach (OrderItem Orderitem in order.Orders)
            {
                if (Orderitem.Order_ID == orderitem.Order_ID)
                {
                    Console.WriteLine($"The Quantity of the product ordered is : {Orderitem.Sale_Quantity}");
                    Console.WriteLine("If you want to modify it Enter yes else Enter no :");
                    bool Entered_Modify = bool.Parse(Console.ReadLine());
                    if ((Entered_Modify.ToString()).ToLower() == "yes")
                    {
                        Console.WriteLine("Enter the new Quantity :");
                        Orderitem.Sale_Quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("The modification has been done.");
                    }
                    else
                    {
                        Get_Order_Payment_Optoin(Orderitem, order);
                        break;
                    }

                    Check_If_Found_In_Orders = true;
                }
            }
            if (!Check_If_Found_In_Orders)
            {
                Console.WriteLine("Order Item is not founded in orders list, Please check the Information of the Order Item .");
            } 
        }
        public void Get_Order_Payment_Optoin(OrderItem Orderitem, Order order)
        {
            Console.WriteLine($"The total is : {Orderitem.Sale_Quantity * Orderitem.Sale_Price}");
            Console.WriteLine("Select the way to check out :");
            Console.WriteLine("1. Credit");
            Console.WriteLine("2. Check");
            Console.WriteLine("3. Cash");
            Console.Write("Enter a number of option selected :");
            int Option_Selected = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (Option_Selected)
            {
                case 1:
                    Console.WriteLine("Enter the Credit Number (16 digits) :");
                    string credit_number_Entered = Console.ReadLine();
                    if (credit_number_Entered.Length != 16)
                    {
                        Console.WriteLine("Wrong Credit Number Check your Info and Try Again.");
                        break;
                    }
                    Console.WriteLine("Enter the Credit Expiring Date of the Credit :");
                    credit.Credit_Expire_Date = Console.ReadLine();
                    Console.WriteLine("Enter the Credit Type of the Credit :");
                    credit.Credit_Type = Console.ReadLine();
                    credit.Payment_Date = DateTime.Now;
                    credit.Payment_Amount = Orderitem.Sale_Quantity * Orderitem.Sale_Price;
                    credit.Payment_Type = "Credit";
                    Customer_Transactions.Add(credit);
                    Orderitem.Order_Status = "Paid";
                    order.Orders.Remove(Orderitem);
                    Console.WriteLine("The payment is done successfully.");
                    break;
                case 2:
                    Console.WriteLine("Enter the Bank Name :");
                    check.Bank_Name = Console.ReadLine();

                    Console.WriteLine("Enter Bank ID :");
                    check.Bank_ID = Console.ReadLine();

                    check.Payment_Date = DateTime.Now;
                    check.Payment_Amount = Orderitem.Sale_Quantity * Orderitem.Sale_Price;
                    check.Payment_Type = "Check";
                    Customer_Transactions.Add(check);
                    Orderitem.Order_Status = "Paid";
                    order.Orders.Remove(Orderitem);
                    Console.WriteLine("The payment is done successfully.");
                    break;
                case 3:
                    Console.WriteLine($"The cash value is : {Orderitem.Sale_Quantity * Orderitem.Sale_Price}");
                    cash.Payment_Date = DateTime.Now;
                    cash.Payment_Amount = Orderitem.Sale_Quantity * Orderitem.Sale_Price;
                    cash.Payment_Type = "Check";
                    Customer_Transactions.Add(cash);
                    Orderitem.Order_Status = "Paid";
                    order.Orders.Remove(Orderitem);
                    Console.WriteLine("The payment is done successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid Option,Try Again!");
                    Get_Order_Payment_Optoin(Orderitem,order); 
                    break;   
            }
        }
        public void Print_Payment_Transactions()
        {
            Console.WriteLine("The Payment Transactions are :");
            int i = 1;
            foreach (Payment payment in Customer_Transactions)
            {
                Console.WriteLine($"The Information of Payment {i}");
                Console.WriteLine($"The Payment Date  is:{payment.Payment_Date}.");
                Console.WriteLine($"The Payment Amoun is:{payment.Payment_Amount}.");
                Console.WriteLine($"The Payment Type  is:{payment.Payment_Type}.");
                i++;
                Console.WriteLine("<>--------------------------------------------------------------<>");
                  
            }
        }
    }
}
