using ShoppingSystem;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCartModel shoppingCart = new ShoppingCartModel();
            string userInput;

            do
            {
                ShoppingLogic.AddItemToCart(shoppingCart);
                Console.Write("Do want to add another item(yes/no): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() != "yes")
                {
                    break;
                }

            } while (true);

            // remove item remove cart 
            Console.ReadLine(); 
        }
    }
}
