using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem
{
    public class ShoppingLogic
    {
        public static void AddItemToCart(ShoppingCartModel shoppingCart)
        {
            

            // Ask for Item they want to add to their cart
            Console.Write("What product do you want to add to your cart: ");
            string productName = Console.ReadLine();

            
            // Ask for the price of the product 
            Console.Write("Enter the price of the product: ");
            string productPriceText = Console.ReadLine();
            decimal productPrice = 0;
            bool isValidProductPrice = decimal.TryParse(productPriceText, out productPrice);
            while (isValidProductPrice == false)
            {
                Console.WriteLine("Invalid input. Please enter a valid price");
                Console.Write("Enter the price of the product: ");
                productPriceText = Console.ReadLine();
                isValidProductPrice = decimal.TryParse(productPriceText,out productPrice);

            }


            // Ask how many quantity 
            Console.Write("Enter the quantity: ");
            string productQuantityText = Console.ReadLine();
            int productQuantity = 0;
            bool isValidQuantity = int.TryParse(productQuantityText, out productQuantity);
            while (isValidQuantity == false) 
            {
                Console.WriteLine("Invalid input. Please enter a valid price");
                Console.Write("Enter the quantity: ");
                productQuantityText = Console.ReadLine();
                isValidQuantity = int.TryParse(productQuantityText,out productQuantity);
            }

            // Create a new product and add it to the cart
            ProductModel newProduct = new ProductModel
            {
                Name = productName,
                Price = productPrice,
                Quantity = productQuantity
            };

            // add to cart
           if(shoppingCart.cart == null)
            {
                shoppingCart.cart = new List<ProductModel>();
            } 

           shoppingCart.cart.Add(newProduct);
            Console.WriteLine($"You added {productQuantity} {productName} added to the cart.");




        }

        public static List<ProductModel> RemoveItemFromCart(List<ProductModel> shoppingCart, string productName) 
        { 
                // ask for name of the product to remove
                    // check if it matches name in cart - ForLoop
                         // check if there <1 quantity of product s
                            // ask how much they want to remove
                                // remove item(s) from cart
                    

                


            return shoppingCart;
            
        }

        public static decimal GetTotalInCart(List<ProductModel> shoppingCart)
        {
            decimal total = 0;

            // loop through items in cart 
                // quantity * price = total
                    // add to total


            return total;
           
        }
    }
}
