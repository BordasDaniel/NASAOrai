namespace NASACLI
{
    public class Program
    {
        public static List<Kuldetes> kuldetesek = [];

        public static void Beolvas()
        {
            using (var sr = new StreamReader("NASAmissions.txt"))
            {
                sr.ReadLine(); // fejléc
                while (!sr.EndOfStream)
                {
                  kuldetesek.Add(new(sr.ReadLine()));
                }
            }
        }

        static void Feladat4()
        {
            Kuldetes? talalat = null;

            do
            {
                Console.Write("Adja meg egy küldetés nevének egy részletét: ");
                string reszlet = Console.ReadLine();

                talalat = kuldetesek.Where(k => k.Nev.Contains(reszlet)).OrderByDescending(l => l.Ev).FirstOrDefault();

            } while(talalat == null);

            Console.WriteLine($"Talált küldetés: {talalat.Nev}, {talalat.Ev}, {talalat.Celpont}, {(talalat.Sikeres ? "Sikeres" : "Sikertelen")}");

        }

        static void Feladat5()
        {
            Console.WriteLine($"5. feladat: Küldetések kockázati szintjei: ");
            foreach (var k in kuldetesek)
            {
                if (k.KockazatiSzint() == "Magas") Console.WriteLine($"{k.Nev}: {k.KockazatiSzint()}");
            }
        }

        static void Feladat6()
        {
            Kuldetes minimumTeher = kuldetesek.OrderByDescending(l => l.HasznosTeher).FirstOrDefault();
            Console.WriteLine($"6. feladat: A legkisebb hasznos teher {minimumTeher.HasznosTeher}kg {minimumTeher.Nev}");
        }


        static void Main(string[] args)
        {
            Beolvas();
            Console.WriteLine($"3. feladat: {kuldetesek.Count} küldetés található az állományban.");
            Feladat4();
            Feladat5();
            Feladat6();

            Console.ReadKey();
        }
    }
}
