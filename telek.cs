using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utca
{
    class telek
    {
        int oldal;
        int front;
        string szin;
        int hazszam;

        public int Oldal { get => oldal; set => oldal = value; }
        public int Front { get => front; set => front = value; }
        public string Szin { get => szin; set => szin = value; }
        public int Hazszam { get => hazszam; set => hazszam = value; }

        public telek(int oldal, int front, string szin, int hazszam)
        {
            this.oldal = oldal;
            this.front = front;
            this.szin = szin;
            this.hazszam = hazszam;
        }

    }
}
