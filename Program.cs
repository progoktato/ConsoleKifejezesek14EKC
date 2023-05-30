using System.Linq.Expressions;

namespace ConsoleMuveletek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //a)
            List<Kifejezes> kifejezesek = new List<Kifejezes>();

            var sorok = File.ReadAllLines("kifejezesek.txt");

            foreach (var s in sorok)
            {
                var mezok = s.Split();
                kifejezesek.Add(new Kifejezes(int.Parse(mezok[0]), mezok[1], int.Parse(mezok[2])));
            }
            Console.WriteLine("Beolvasás készen van!");

            //b) LINQ
            List<Kifejezes> kifejezesek2 = File.ReadAllLines("kifejezesek.txt")
                .Select(sor => new Kifejezes(sor)).ToList(); ;

            Console.WriteLine($"2. feladat: Kifejezések száma: {kifejezesek.Count}");


            int eredmeny = kifejezesek.Count(x => x.Muvelet == "mod");
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {eredmeny}");

            //hagyományos megoldás
            //int db = 0;
            //foreach (var item in kifejezesek)
            //{
            //    if (item.Muvelet == "mod")
            //    {
            //        db++;
            //    }
            //}

            bool eredmenyBool = kifejezesek.Any(x => x.OperandusBal % 10 == 0 && x.OperandusJobb % 10 == 0);
            Console.WriteLine($"4. feladat: {(eredmenyBool ? "Van" : "Nincs")} ilyen kfejezés");

            Console.WriteLine("5. feladat: Statisztika");
            kifejezesek.Where(x => ValosOperator(x.Muvelet))
                       .GroupBy(x => x.Muvelet)
                       .ToList()
                       .ForEach(x => Console.WriteLine($"\t{x.Key} -> {x.Count()} db"));

            //Másként írva
            var csoportok = kifejezesek.Where(x => ValosOperator(x.Muvelet)).GroupBy(x => x.Muvelet);
            foreach (var csoport in csoportok)
            {
                Console.WriteLine($"\t{csoport.Key} -> {csoport.Count()} db");
            }


            string inputTxt = "";
            do
            {
                Console.Write($"7. feladat: Kérek egy kifejezést (pl.: 1 + 1):");
                inputTxt = Console.ReadLine();
                if (inputTxt.ToLower() != "vége")
                {
                    Console.WriteLine($"\t{new Kifejezes(inputTxt).Eredmeny()}");
                }
            } while (inputTxt.ToLower() != "vége");

            Console.WriteLine("8. feladat: eredmenyek.txt");
            File.WriteAllLines("eredmenyek.txt", kifejezesek.Select(ob => ob.Eredmeny()));

            // u.ez StreamWriter segítségével
            //StreamWriter sw = new StreamWriter("eredmenyek.txt");
            //foreach (var aktKif in kifejezesek)
            //{
            //    sw.WriteLine(aktKif.Eredmeny());
            //}
            //sw.Close();
        }




        static string[] LetezoMuveletek = { "+", "-", "*", "/", "mod", "div" };
        private static bool ValosOperator(String muvelet)
        {
            foreach (var item in LetezoMuveletek)
            {
                if (item == muvelet)
                {
                    return true;
                }
            }
            return false;
        }
    }
}