using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASACLI
{
    public class Kuldetes
    {
        public string Nev { get; private set; }
        public int Ev { get; private set; }
        public string Celpont { get; private set; }
        public int Legenyseg { get; private set; }
        public bool Sikeres { get; private set; }
        public string Leiras { get; private set; }
        public double Koltseg { get; private set; }
        public double HasznosTeher { get; private set; }

        public Kuldetes(string sor)
        {
            string[] strs = sor.Split(';');
            Nev = strs[0];
            Ev = int.Parse(strs[1]);
            Celpont = strs[2];
            Legenyseg = int.Parse(strs[3]);
            Sikeres = strs[4] == "Igen";
            Leiras = strs[5];
            Koltseg = double.Parse(strs[6]);
            HasznosTeher = double.Parse(strs[7]);
        }

        public string KockazatiSzint()
        {
            return (HasznosTeher, Koltseg) switch
            {
                ( > 10, > 1000000000) => "Magas",
                ( < 10, > 1000000000) or ( > 10, < 1000000000) => "Közepes",
                _ => "Alacsony"
            };
        }
    }
}
