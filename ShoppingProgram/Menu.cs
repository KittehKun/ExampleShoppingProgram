using System.Collections;

namespace ShoppingProgram
{
    class Menu
    {
        private ArrayList menuOptions = new ArrayList();

        //Constructors
        public Menu()
        {
            menuOptions.Add("1. Display Menu");
            menuOptions.Add("2. Source Inventory");
            menuOptions.Add("3. Exit");
        }

        //Methods
        private void InitializeMenu()
        {
            foreach (string element in menuOptions)
            {
                Console.WriteLine(element);
            }
        }

        public void DisplayMenu()
        {
            InitializeMenu();
            try
            {
                int menuSelection = Convert.ToInt32(Console.ReadLine());
                switch(menuSelection)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Here is our selection of goods:\n");
                        Goods.DisplayInventory();
                        DisplayMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Do you want to add an item? (Y/N)");
                        string choice = Console.ReadLine()!.ToUpper(); //Exclamation Mark means the value can be null
                        if(choice == "Y")
                        {
                            AddNewItem();
                            Console.Clear();
                            DisplayMenu();
                            break;
                        } else if(choice == "N")
                        {
                            DisplayMenu();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input. Returning to menu...");
                            DisplayMenu();
                            break;
                        }
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Exiting Program...");
                        Environment.Exit(0); //Exits the program
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Not sure how this was possible. DEBUGGING NEEDED!");
                        break;
                }
            } catch (Exception errorMessage)
            {
                Console.Clear();
                Console.WriteLine($"ERROR ENCOUNTERED: {errorMessage}");
                Console.WriteLine();
                DisplayMenu();
            }
        }

        private void AddNewItem()
        {
            Console.WriteLine("What's the name of the item you want to add?");
            string name = Console.ReadLine() ?? throw new ArgumentException("Invalid Answer");
            Console.WriteLine("How much does the item cost?");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is the description of the item?");
            string description = Console.ReadLine()!;
            Goods goods = new(name, price, description);
            goods.ToInventory(goods);
        }
    }
}
