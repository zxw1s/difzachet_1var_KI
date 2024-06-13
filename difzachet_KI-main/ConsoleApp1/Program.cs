using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Putevka> putevki = new List<Putevka>();
            string[] lines = File.ReadAllLines("data.txt");
            foreach(string line in lines)
            {
                string[] parts = line.Split(' ');
                putevki.Add(new Putevka
                {
                    Id=int.Parse(parts[0]),
                    Name=parts[1],
                    Country=parts[2],
                    Kolvo = int.Parse(parts[3]),
                    Price = int.Parse(parts[4]),
                });
            };
            Console.WriteLine("введите ID строки которую хотите удалить");
            var idRemove = int.Parse(Console.ReadLine());
            putevki.RemoveAll(x => x.Id == idRemove);
            var result = from putevka in putevki
                         select new
                         {
                             putevka.Id,
                             putevka.Name,
                             putevka.Country,
                             putevka.Kolvo,
                             putevka.Price
                         };

            foreach (var putevka in result)
            {
                Console.WriteLine($"Путёвка:{putevka.Id}, Отель:{putevka.Name}, Страна:{putevka.Country}, Количество:{putevka.Kolvo}, Цена:{putevka.Price}");
            }
            Console.ReadLine();
        } 
    }
}
