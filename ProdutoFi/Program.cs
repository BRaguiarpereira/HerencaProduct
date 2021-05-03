using System;
using System.Globalization;
using ProdutoFi.Entities;
using System.Collections.Generic;
namespace ProdutoFi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando lista de produtos 
            List<Product> list = new List<Product>();

            Console.WriteLine("ENTRE COM O NUMERO DE PRODUTOS : ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Produto #{i}");
                Console.WriteLine("SEU PRODUTO É COMUM , USADO OU IMPORTADA(C/U/I) ? ");
                char ch = char.Parse(Console.ReadLine());
                Console.WriteLine("Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Price :");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'c')
                {
                    list.Add(new Product(name, price));

                    
                } else if(ch == 'i')
                {
                   
                    Console.WriteLine("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new ImportedProduct(name, price, customsFee));

                } else if(ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    list.Add(new UsedProduct(name, price, date));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }

        }
    }
}
