using System.Runtime.CompilerServices;

namespace sales_order_app_project
{
    
    internal class OrderItem
    {
        enum Order_Status_Options
        {
            New = 1,
            Hold = 2,
            Paid = 3,
            Canceled = 4
        }
        public int Order_ID;
        public double Sale_Price;
        public int Sale_Quantity;
        public DateTime Order_date;
        public int Order_Number;
        public String Order_Status;

        public void Update_Quantity(int ProductID, int Product_Quantity,int Case_Selected)
        {
            if(this.Check_Product_Existance_And_Quantitiy(ProductID, Product_Quantity))
            {
                foreach (Product p in Stock.Product_In_Stock)
                {
                    if (p.Product_ID==ProductID)
                    {
                        if (Case_Selected == 1)
                        {
                            if (p.Product_Quantity >= Product_Quantity)
                            {
                                p.Product_Quantity -= Product_Quantity;
                                Console.WriteLine("The quantity is reduced Successfully.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The quantity you entered is more than the order Quantity.");
                                break;
                            }

                        }
                        else
                        {
                            p.Product_Quantity += Product_Quantity;
                            Console.WriteLine("The quantity is increased successfully.");
                        }
                    }
                }
            }

        }
        public bool Check_Product_Existance_And_Quantitiy(int productId,int Product_Quantity_On_Sale)
        {
            bool CheckFound = false,CheckQuantity=false;
            foreach (Product p in Stock.Product_In_Stock)
            {
                if (p.Product_ID==productId)
                {
                    CheckFound = true;

                    if (Product_Quantity_On_Sale <= p.Product_Quantity)
                    {
                        CheckQuantity = true;
                    }
                }
            }
            if(CheckFound)
            {
                if(CheckQuantity)
                {
                    return true;
                }
                else
                {   
                    Console.WriteLine("The Product Quantity is Greater than the Quantity in Stock.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The Product is Out Of Stock.");
                return false;
            }

        }
        private Order_Status_Options Get_Customer_Selection_Operation_Order()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. New Order ");
            Console.WriteLine("2. Hold Order ");
            Console.WriteLine("3. Paid Order ");
            Console.WriteLine("4. Canceled Order ");


            int Select_Option;
            if (int.TryParse(Console.ReadLine(), out Select_Option))
            {
                if (Enum.IsDefined(typeof(Order_Status_Options), Select_Option))
                {
                    return (Order_Status_Options)Select_Option;
                }
            }
            Console.WriteLine("Invalid selection. Please try again.");
            return Get_Customer_Selection_Operation_Order();
        }
        public void Select_Order_Status()
        {
            Order_Status_Options Info_Select = Get_Customer_Selection_Operation_Order();
            switch (Info_Select)
            {
                case Order_Status_Options.New:
                    Order_Status = "NEW";
                    break;
                case Order_Status_Options.Hold:
                    Order_Status = "HOLD";
                    break;
                case Order_Status_Options.Paid:
                    Order_Status = "PAID";
                    break;
                case Order_Status_Options.Canceled:
                    Order_Status = "CANCELED";
                    break;
            }

        }

    }
}
