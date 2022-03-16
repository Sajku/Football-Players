using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_2
{
    internal class Piłkarz
    {
        private string imie;
        internal string Imie {
            get
            {
                return imie;
            }
            set {
                imie = value;

            }
        }

        public string Nazwisko { get; set; }
        public int Waga { get; set; }
        public int Wzrost { get; set; }
        public Pozycja Pozycja { get; set; }

        public Piłkarz(string imie, string nazwisko, int waga, int wzrost, Pozycja pozycja)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Waga = waga;
            Wzrost = wzrost;
            Pozycja = pozycja;
        }

        public override string ToString()
        {
            return $"{Nazwisko} {Imie}, p: {Pozycja}, waga: {Waga}[kg], wzrost: {Wzrost}[cm]";
        }
    }
}
