namespace Vending_Machine
{
    internal class Program
    {
        static void dashboard(int funds, ref Dictionary<string, int[]> products)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to your dashboard!");
            string choice = null;
            while (choice == null)
            {
                Console.WriteLine("Where would you like to go?");
                Console.Write("1 The Vending Machine, 2 Wallet or 3 inventory?");
                Console.WriteLine();
                choice = Console.ReadLine();

                if (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Sorry but that is not a valid location, please try again.");
                    choice = null;
                }

                if (choice == "1")
                {
                    // The vending machine
                    vendingMachine(funds, ref products);
                }
                else if (choice == "2")
                {
                    // display current quantity of funds
                    wallet(funds, ref products);
                }
                else if (choice == "3")
                {
                    // display current owned items
                    invetntory(funds, ref products);
                }
            }
        }
        static void wallet(int funds, ref Dictionary<string, int[]> products) {
            Console.WriteLine();
            Console.WriteLine("Current funds in your wallet: " + funds);
            dashboard(funds, ref products);
        }
        static void invetntory(int funds, ref Dictionary<string, int[]> products)
        {
            Console.WriteLine();
            Console.WriteLine("currntly owned items:");
            Console.WriteLine("Item: quantity:");

            //whrites out all the products 
            foreach (var product in products)
            {
                var values = product.Value;
                Console.WriteLine($"{product.Key}: {values[1]}");
            }

            dashboard(funds, ref products);
        }
        static void vendingMachine(int funds, ref Dictionary<string, int[]> products)
        {
            Console.WriteLine();
            var productId = 1;
            foreach (var product in products) // same loop as in invetory
            {
                var values = product.Value;
                Console.WriteLine($"{productId}. {product.Key}: ${values[0]}");
                productId++;
            }

            productSelection(funds, ref products);

            static void productSelection(int funds, ref Dictionary<string, int[]> products)
            {
                string choice = null;
                Console.WriteLine("What product would you want to buy? Press 0 to leave.");
                Console.WriteLine();
                choice = Console.ReadLine();

                switch (choice) // used a switch case isted of else if statments to make it a bit lighter on the system 
                {
                    case "0":
                        dashboard(funds, ref products);
                        break;
                    case "1": // tells you what you have purchased, removes the funds form the wallet and adds the item to the 
                        if (funds >= products["Coke"][0])
                        {
                            Console.WriteLine("One Coke has been purchased.");
                            funds -= products["Coke"][0];
                            products["coke"][1]++;
                        } 
                        else
                        {   // if the user dont have the money for the product it sends them back to the selection.
                            Console.WriteLine("Sorry you dont seam to have the money for this purchas.");
                            productSelection(funds, ref products);
                        }
                        break;
                    case "2":
                        if (funds >= products["Fanta"][0])
                        {
                            Console.WriteLine("One Fanta has been purchased.");
                            funds -= products["Fanta"][0];
                            products["Fanta"][1]++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry you dont seam to have the money for this purchas.");
                            productSelection(funds, ref products);
                        }

                        break;
                    case "3":
                        if (funds >= products["Pepsi"][0])
                        {
                            Console.WriteLine("One Pepsi has been purchased.");
                            funds -= products["Pepsi"][0];
                            products["Pepsi"][1]++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry you dont seam to have the money for this purchas.");
                            productSelection(funds, ref products);
                        }
                        break;
                    case "4":
                        if (funds >= products["Sprite"][0])
                        {
                            Console.WriteLine("One Sprite has been purchased.");
                            funds -= products["Sprite"][0];
                            products["Sprite"][1]++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry you dont seam to have the money for this purchas.");
                            productSelection(funds, ref products);
                        }
                        break;
                    case "5":
                        if (funds >= products["Coffee"][0])
                        {
                            Console.WriteLine("One Coffee has been purchased.");
                            funds -= products["Coffee"][0];
                            products["Coffee"][1]++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry you dont seam to have the money for this purchas.");
                            productSelection(funds, ref products);
                        }
                        break;
                    case "6":
                        if (funds >= products["Tea"][0])
                        {
                            Console.WriteLine("One Tea has been purchased.");
                            funds -= products["Tea"][0];
                            products["Tea"][1]++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry you dont seam to have the money for this purchas.");
                            productSelection(funds, ref products);
                        }
                        break;
                    default: // if none of the corect choices have been made loop back to the begining
                        Console.WriteLine("Sorry but that is not a valid choice, please try again.");
                        productSelection(funds, ref products);
                        break;
                }
                productSelection(funds, ref products); // loop back to the begining,
                // did this becouse i think it would be anoying to be sent back to the dashboard after every purchas
            }
        }
        public static void Main(string[] args)
        {
            // creating some important vars that are gonna be used in multiple 
            // places.

            int funds = 150;

            // sets up the dictionary that is the heart of the entire script
            Dictionary<string, int[]> products = new Dictionary<string, int[]>();

            products.Add("Coke", new int[] { 5, 0 });
            products.Add("Fanta", new int[] { 5, 0 });
            products.Add("Pepsi", new int[] { 5, 0 });
            products.Add("Sprite", new int[] { 5, 0 });
            products.Add("Coffee", new int[] { 5, 0 });
            products.Add("Tea", new int[] { 5, 0 });

            // the start of the interactive portion of the script
            dashboard(funds, ref products);

            }
        }
    }
