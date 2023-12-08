namespace sales_order_app_project
{
    enum Product_Info_Select
    {
        Product_ID=1, 
        Product_Name=2, 
        Product_Number=3,
        Product_Price=4,
        Product_Type=5,
        Product_Quantity=6,
    }
    class Product
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Number { get; set; }
        public double Product_Price { get; set; }
        public int Product_Type { get; set; }
        public int Product_Quantity { get; set; }
        public Product()
        {

        }
        public Product(int ProductQuantity)
        {
            this.Product_Quantity = ProductQuantity;
        }
        
        private Product_Info_Select Get_Customer_Selection_Info()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Product ID");
            Console.WriteLine("2. Product Name");
            Console.WriteLine("3. Product Number");
            Console.WriteLine("4. Product Price");
            Console.WriteLine("5. Product Type");
            Console.WriteLine("6. Product Quantity");


            int Select_Option;
            if(int.TryParse(Console.ReadLine(), out Select_Option)) { 
                if(Enum.IsDefined(typeof(Product_Info_Select), Select_Option))
                {
                    return (Product_Info_Select)Select_Option;
                }
            }
            Console.WriteLine("Invalid selection. Please try again.");
            return Get_Customer_Selection_Info();
        }
        public void Update_Product_Info()
        {
            Product_Info_Select Info_Select = Get_Customer_Selection_Info();
            switch(Info_Select)
            {
                case Product_Info_Select.Product_ID:
                    Console.Write("Enter the new ID :");
                    Console.WriteLine();
                    this.Product_ID = int.Parse(Console.ReadLine());
                    break;
                case Product_Info_Select.Product_Number:
                    Console.Write("Enter the new Number : ");
                    this.Product_Number = Console.ReadLine();
                    Console.WriteLine();
                    break;
                case Product_Info_Select.Product_Name:
                    Console.Write("Enter the new Name : ");
                    this.Product_Name = Console.ReadLine();  
                    Console.WriteLine();
                    break;
                case Product_Info_Select.Product_Price:
                    Console.Write("Enter the new Price : ");
                    this.Product_Price= double.Parse(Console.ReadLine());  
                    Console.WriteLine();
                    break;
                case Product_Info_Select.Product_Type:
                    Console.Write("Enter the new Type : ");
                    this.Product_Type= int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    break;
                case Product_Info_Select.Product_Quantity:
                    Console.Write("Enter the new Quantity : ");
                    this.Product_Type=int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    break;
            }

        }
        public void Get_Product_Info()
        {
            Console.WriteLine($"The ID of the Product : {Product_ID} .");
            Console.WriteLine($"The Name of the Product : {Product_Name} .");
            Console.WriteLine($"The Price of the Product : {Product_Price} .");
            Console.WriteLine($"The Number of the Product : {Product_Number} .");
            Console.WriteLine($"The Type of the Product : {Product_Type} .");
            Console.WriteLine($"The Type of the Product : {Product_Quantity} .");
        }
        public bool Same_Product(Product product)
        {
            return (product.Product_ID == this.Product_ID);
        }
        public static Product operator +(Product product,int Quantity)
        {
            return new Product(product.Product_Quantity + Quantity);
        }
        
    }
}
