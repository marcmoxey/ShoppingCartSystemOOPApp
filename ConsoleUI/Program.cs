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

            ShoppingLogic.DisplayCart(shoppingCart);
            // remove item remove cart 
            Console.Write("Do you want to remove item(s) from your cart(yes/no): ");
            Console.WriteLine();
            do
            {
                Console.Write("What is the name of item(s) you want to remove: ");
                userInput = Console.ReadLine();
                ShoppingLogic.RemoveItemFromCart(shoppingCart, userInput);

                if (userInput.ToLower() != "yes") 
                {
                   break;
                }
            }
            while (true);

            ShoppingLogic.GetTotalInCart(shoppingCart);
            Console.ReadLine(); 
        }
    }
}
