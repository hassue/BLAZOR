using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
           // AddSamurai("Julie");
            RemoveSamurai("Julie");
            //GetSamurais("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void RemoveSamurai(string v)
        {
            var samurais = _context.Samurais.Where(w => w.Name == v).FirstOrDefault();
            if (samurais!=null)
            {
                _context.Samurais.Remove(samurais);
                _context.SaveChanges();
            }
        }

        private static void AddSamurai(string name)
        {
            var samurai = new Samurai { Name = name };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text} Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
