namespace sales_order_app_project
{
    class Stock
    {
        
        public static List<Product> Product_In_Stock;
        public Stock() {
            Product_In_Stock = new List<Product>();
        }
        
        public void Add_Stock(Product product,int Quantity)
        {
            var CheckFound = false;
            foreach (Product p in Product_In_Stock)
            {
                if (p.Same_Product(product))
                {
                    product = product + Quantity;
                    CheckFound = true;
                    break;
                }
            }
            if (!CheckFound)
            {
                Product_In_Stock.Add(product);
  
            }
        }
        public void Update_Stock(int product_id)
        {
            var CheckFound = false;
            foreach (Product p in Product_In_Stock)
            {
                if (p.Product_ID==product_id)
                {
                    p.Update_Product_Info();
                    break;
                }
            }
            if (CheckFound)
            {
                Console.WriteLine("Product Entered Is Not Found!");

            }
        }
        public void Delete_Stock(int product_id)
        {
            var CheckFound = false;
            foreach (Product p in Product_In_Stock)
            {
                if (p.Product_ID==product_id)
                {
                    Product_In_Stock.Remove(p);
                    CheckFound = true;
                    break;
                }
            }
            if(CheckFound) { 
                Console.WriteLine("Product is deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Product Entered Is Not Found!");
            }
        }
        public void Search_For_Product(int product_id)
        {
            var CheckFound = false;
            foreach (Product p in Product_In_Stock)
            {

                if (p.Product_ID == product_id)
                {  
                    p.Get_Product_Info();
                    CheckFound = true;
                    break;
                }
            }
            if(!CheckFound)
            {
                Console.WriteLine("Product Entered Is Not Found!");
            }

        }
        public void View_all_Products()
        {
            int i = 1;
            foreach(Product product in Product_In_Stock)
            {
                Console.WriteLine($"The info of Product {i}");
                Console.WriteLine();
                Console.WriteLine($"The Product ID {product.Product_ID}");
                Console.WriteLine($"The Product Name {product.Product_Name}");
                Console.WriteLine($"The Product Number {product.Product_Number}");
                Console.WriteLine($"The Product Price {product.Product_Price}");
                Console.WriteLine($"The Product Type {product.Product_Type}");
                Console.WriteLine($"The Product Quantity {product.Product_Quantity}");
                Console.WriteLine();

                Console.WriteLine("<>---------------------------------------------------------------------------------<>");
            }
        }

    }
}
