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

        public static ShoppingCartModel RemoveItemFromCart(ShoppingCartModel shoppingCart, string productName) 
        { 
            // check if the cart is empty 
            if(shoppingCart.cart == null || shoppingCart.cart.Count == 0) 
            {
                Console.WriteLine("Your cart is empty");
            }

            // Find the product in the cart
            ProductModel productToRemove = null;

            foreach (var product in shoppingCart.cart) 
            {
                // check if it matches name in cart 
                if (product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    productToRemove = product;
                }
            }

            // if the product is not found
            if(productToRemove == null)
            {
                Console.WriteLine($"Product '{productName}' not found in the cart.");
                return shoppingCart;
            }

            // ask how much they want to remove
            Console.Write($"How many {productToRemove.Name} do you want to remove (Available): {productToRemove.Quantity}: ");
            string quantityToRemoveText = Console.ReadLine();
            int quantityToRemove = 0;
            bool isValidQuantity = int.TryParse( quantityToRemoveText, out quantityToRemove);


            while(!isValidQuantity || quantityToRemove <= 0 || quantityToRemove > productToRemove.Quantity)
            {
                Console.WriteLine("Invalid input. Please enter a valid quantity.");
                Console.Write($"How many '{productToRemove.Name}' do you want to remove? (Available): {productToRemove.Quantity}): ");
                quantityToRemoveText = Console.ReadLine();
                isValidQuantity = int.TryParse(quantityToRemoveText, out quantityToRemove);
            }


            // Remove item(s) from the cart 
            if (quantityToRemove == productToRemove.Quantity)
            {

                // Remove the entire product if the quantity matches
                shoppingCart.cart.Remove(productToRemove);
                Console.WriteLine($"All {productToRemove.Quantity} '{productToRemove.Name}' have been removed from the cart.");

            }
            else
            {
                // Reduce the quantity of the product 
                productToRemove.Quantity = quantityToRemove;
                Console.WriteLine($"{quantityToRemove} '{productToRemove.Name}' have been removed from the cart.");
            }
                return shoppingCart;
            
        }

        public static decimal GetTotalInCart(ShoppingCartModel shoppingCart)
        {
            decimal total = 0;

            // Check if the cart is empty
            if (shoppingCart.cart == null || shoppingCart.cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return total;
            }

            // Display cart header
            Console.WriteLine("\nShopping Cart");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Product Name\tPrice\tQuantity");

            // Loop through items in the cart
            foreach (var item in shoppingCart.cart)
            {
                decimal itemTotal = item.Price * item.Quantity; // Calculate the total for the current item
                total += itemTotal; // Add to the overall total

                // Display the item details
                Console.WriteLine($"Product: {item.Name}\t${item.Price}\t{item.Quantity}");
            }

            // Display the total
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Total: ${total}");

            return total;
        }

        public static void DisplayCart(ShoppingCartModel shoppingCart) 
        {
            // Check if the cart is empty
            if (shoppingCart.cart == null || shoppingCart.cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            // Display cart header
            Console.WriteLine("\nShopping Cart");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Product Name\tPrice\tQuantity");

            // Loop through items in the cart
            foreach (var item in shoppingCart.cart)
            {
                // Display the item details
                Console.WriteLine($"{item.Name}\t${item.Price}\t{item.Quantity}");
            }

            // Display footer
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
