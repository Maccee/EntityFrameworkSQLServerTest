using System;
using System.Linq;
using ASP_ENTITY.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_ENTITY
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new TutorialDbContext();

            Console.WriteLine("Kenet haetaan?");
            var searchName = Console.ReadLine();

            var customer = context.Customers
                .Where(c => c.Name == searchName)
                .First();

            if (customer != null)
            {
                Console.WriteLine($"ID: {customer.CustomerId}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Location: {customer.Location}");
                Console.WriteLine($"Email: {customer.Email}");
            }
            else
            {
                Console.WriteLine($"Ei löydy: {searchName}");
            }

        }
    }
}
