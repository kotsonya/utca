using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace utca
{
    class Program
    {
        static List<telek> telkek = new List<telek>();
        static string fajl_in = @"f:\suli\szoftverfejleszto\c_sharp\utca\feladat\kerites.txt";
        static string fajl_out = @"f:\suli\szoftverfejleszto\c_sharp\utca\feladat\utcakep.txt";
        static void beolvas()
        {
            using (StreamReader sr = new StreamReader(fajl_in))
            {
                int paros_szam = 0;
                int paratlan_szam = -1;
                while (!sr.EndOfStream)
                {
                    string[] egy_sor = sr.ReadLine().Split(' ');

                    if (Convert.ToInt32(egy_sor[0]) == 0)
                    {
                        paros_szam = paros_szam + 2;
                        telkek.Add(new telek(Convert.ToInt32(egy_sor[0]), Convert.ToInt32(egy_sor[1]), egy_sor[2], paros_szam));
                    }
                    else
                    {
                        paratlan_szam = paratlan_szam + 2;
                        telkek.Add(new telek(Convert.ToInt32(egy_sor[0]), Convert.ToInt32(egy_sor[1]), egy_sor[2], paratlan_szam));

                    }


                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Feladat 1:");
            beolvas();
            Console.WriteLine("Fájl Beolvasva!");
            Console.ReadKey();

            Console.WriteLine("\nFeladat 2:");
            Console.WriteLine($"Az utcában {telkek.Count()}db telket adtak el!");
            Console.ReadKey();

            Console.WriteLine("\nFeladat 3:");
            Console.WriteLine($"Az utcában az utolsó telket a {((telkek.Last().Oldal == 0) ? "páros" : "páratlan")}oldalon adták el!");
            Console.WriteLine($"A házszáma: {telkek.Last().Hazszam}");
            Console.ReadKey();

            Console.WriteLine("\nFeladat 4:");
            List<telek> paratlan_oldal = new List<telek>(telkek.FindAll(x => x.Oldal == 1));
            for (int i = 0; i < paratlan_oldal.Count(); i++)
            {
                if ((paratlan_oldal[i].Szin != ":") && (paratlan_oldal[i].Szin != "#") && (paratlan_oldal[i].Szin == paratlan_oldal[i + 1].Szin))
                {
                    Console.WriteLine($"A szomszédossal egyezik a kerítés színe: {paratlan_oldal[i].Hazszam}");
                    break;
                }
            }

            Console.WriteLine("\nFeladat 5:");
            Console.Write("Adjon meg egy házszámot! ");
            int melyik_hazszam = Convert.ToInt32(Console.ReadLine());
            string szinek = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random uj_szin_rnd = new Random(szinek.Length);
            int uj_szin;

            Console.WriteLine($"A kerítés színe / állapota: {telkek.Find(x => x.Hazszam == melyik_hazszam).Szin}");
            do
            {
                uj_szin = uj_szin_rnd.Next(szinek.Length);

            }
            while (telkek.Find(x=> x.Hazszam == melyik_hazszam).Szin == Convert.ToString(szinek[uj_szin]));

            Console.WriteLine($"Egy lehetséges festési szín: {szinek[uj_szin]}");
            Console.ReadKey();

            Console.WriteLine("\nFeladat 6:");

            string elso_sor = "";
            string masodik_sor = "";

            for (int i = 0; i < paratlan_oldal.Count(); i++)
            {
                masodik_sor += paratlan_oldal[i].Szin;
                elso_sor += paratlan_oldal[i].Szin;

                for (int j = 1; j < paratlan_oldal[i].Front; j++)
                {
                    elso_sor += paratlan_oldal[i].Szin;
                    masodik_sor += " ";

                }

            }
            using (StreamWriter sw = new StreamWriter(fajl_out))
            {
                sw.WriteLine(elso_sor);
                sw.Write(masodik_sor);
            }
            Console.WriteLine("Kiírás megtörtént!");
            Console.ReadKey();


            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
    }
}
