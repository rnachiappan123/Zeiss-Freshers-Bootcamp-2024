using System;
using System.Collections.Generic;

namespace FreshersBootcamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Product> products = null;
            bool loop = true;

            do
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Find");
                Console.WriteLine("4. Remove");
                Console.WriteLine("5. Exit\n");

                byte option = Convert.ToByte(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        products = new Dictionary<int, Product>();
                        bool addAnother;

                        do
                        {
                            Product product = new Product();
                            addAnother = false;

                            try
                            {
                                Console.Write("Enter Product ID: ");
                                int _id = Convert.ToInt32(Console.ReadLine());

                                if (products.ContainsKey(_id))
                                {
                                    throw new ArgumentException($"Product {_id} already exists");
                                }

                                product.ProductID = _id;

                                Console.Write("Enter Product Name: ");
                                product.Name = Console.ReadLine();

                                Console.Write("Enter Date of Manufacturing: ");
                                product.MfgDate = Convert.ToDateTime(Console.ReadLine());

                                Console.Write("Enter Price: ");
                                product.Price = Convert.ToDouble(Console.ReadLine());

                                Console.Write("Enter Stock: ");
                                product.Stock = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter GST: ");
                                product.Gst = Convert.ToByte(Console.ReadLine());

                                Console.Write("Enter Discount: ");
                                product.Discount = Convert.ToByte(Console.ReadLine());

                                product.CalculatePrices();
                                products.Add(_id, product);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            Console.Write("\nAdd another product? (y|N): ");
                            string choice = Console.ReadLine();

                            if (String.Equals(choice.ToLower(), "y"))
                            {
                                addAnother = true;
                            }

                            Console.WriteLine();
                        } while (addAnother);
                        break;

                    case 2:
                        if (products != null)
                        {
                            foreach (var item in products.Values)
                            {
                                Console.WriteLine(item.Display());
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No products to display\n");
                        }
                        break;

                    case 3:
                        if (products == null)
                        {
                            Console.WriteLine("Product list empty\n");
                            break;
                        }

                        try
                        {
                            Console.Write("Enter Product ID to find: ");
                            int _id = Convert.ToInt32(Console.ReadLine());

                            if (products.ContainsKey(_id))
                            {
                                Console.WriteLine(products[_id].Display());
                            }
                            else
                            {
                                Console.WriteLine($"Product {_id} not found\n");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "\n");
                        }
                        break;

                    case 4:
                        if (products == null)
                        {
                            Console.WriteLine("Product list empty\n");
                            break;
                        }

                        try
                        {
                            Console.Write("Enter Product ID to remove: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (products.ContainsKey(id))
                            {
                                products.Remove(id);
                                Console.WriteLine($"Product {id} removed\n");
                            }
                            else
                            {
                                Console.WriteLine($"Product {id} not found\n");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "\n");
                        }
                        break;

                    case 5:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Enter a valid option\n");
                        break;
                }
            }
            while (loop);
        }
    }
}