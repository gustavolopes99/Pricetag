using System.Globalization;
using Prod.Entities;

namespace Prod
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.Write("Enter the number of products: ");
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} date:");
                Console.Write("Common, used or imported (c/u/i)? ");
                var kind = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Price: ");
                var price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                switch (kind)
                {
                    case 'i':
                        Console.Write("Customs fee: ");
                        var customsfee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        products.Add(new ImportedProduct(name, price, customsfee));
                        break;
                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        var date = DateTime.Parse(Console.ReadLine());
                        products.Add(new UsedProduct(name, price, date));
                        break;
                    default:
                        products.Add(new Product(name, price));
                        break;
                }
            }
            Console.WriteLine("PRICE TAGS:");
            foreach (var item in products)
            {
                Console.WriteLine(item.priceTag());
            }

        }
    }
}