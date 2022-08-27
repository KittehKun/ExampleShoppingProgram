using System.Collections;

namespace ShoppingProgram
{
    class Goods : IItem
    {

        public static ArrayList goodsList = new ArrayList();

        public string Name { get ; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Goods(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        //Adds created Goods into Inventory
        public void ToInventory(Goods goods)
        {
            goodsList.Add(goods);
        }

        public static void DisplayInventory()
        {
            foreach(Goods goods in goodsList)
            {
                Console.WriteLine($"Item Name: {goods.Name}");
                Console.WriteLine($"Item Cost: ${goods.Price.ToString("0.00")}");
                Console.WriteLine($"Description of item: {goods.Description}\n");
            }
        }
    }
}
