using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace ConsoleApp1

//zajecia 11.01.2025
{
    //zad.1
    public class Ksiazka
    {
        public string Gatunek { get; set; }
        public int RokWydania { get; set; }

        // Konstruktor
        public Ksiazka(string gatunek, int rokWydania)
        {
            Gatunek = gatunek;
            RokWydania = rokWydania;
        }

        // Metoda do wyświetlania informacji o książce
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Gatunek: {Gatunek}, Rok wydania: {RokWydania}");
        }
    }

    //zad.2
    public class Produkt
    {
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        // Konstruktor
        public Produkt(string nazwa, decimal cena)
        {
            Nazwa = nazwa;
            Cena = cena;
        }

        public override string ToString()
        {
            return $"{Nazwa}: {Cena} PLN";
        }
    }

    public class Koszyk
    {
        private List<Produkt> produkty;
        public decimal SumaCen { get; private set; }

        // Konstruktor
        public Koszyk(List<Produkt> produkty)
        {
            this.produkty = produkty;
            SumaCen = ObliczSumeCen();
        }

        // Metoda do obliczania sumy cen produktów
        private decimal ObliczSumeCen()
        {
            decimal suma = 0;
            foreach (var produkt in produkty)
            {
                suma += produkt.Cena;
            }
            return suma;
        }

        public void WyswietlProdukty()
        {
            Console.WriteLine("Produkty w koszyku:");
            foreach (var produkt in produkty)
            {
                Console.WriteLine(produkt);
            }
            Console.WriteLine($"Suma cen: {SumaCen} PLN");
        }
    }

    //zad.3
    public class Klient
    {
        private string imie;
        public int nrKlienta { get; private set; }

        public Klient (string imie, int nrKlienta)
        {
            this.imie = imie;
            this.nrKlienta = nrKlienta;

        }

        public void WyswietlInfo()
        {

            Console.WriteLine($"Imie: {imie} , Numer Klienta: {nrKlienta}");
        }

     }

    public class Sklep
    {

        private Klient[] klienci;
        private int liczbaKlientow;

        public Sklep(int maxLiczbaKlientow)
        {

            klienci = new Klient[maxLiczbaKlientow];
            liczbaKlientow = 0;

        }

        public void DodKlienata(Klient klient)
        {
            if (liczbaKlientow < klienci.Length) 
            {

                klienci[liczbaKlientow] = klient;
                liczbaKlientow++;
                Console.WriteLine($"Dodano klienta: {klient.nrKlienta}");
            
            }
            else
            {

                Console.WriteLine("Sklep pelny.");

            }
        }
        public int LiczbaKlientow
        {

            get { return liczbaKlientow; }
        }
        public void WyswietlKlientow()
        {

            Console.WriteLine("Klienci w sklepie:");
            for (int i = 0; i < liczbaKlientow; i++)
            {

                klienci[i].WyswietlInfo();

            }

        }

    }

    //zad.4
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        //obliczanie odl miedzy dwoma pkt
        public double OblOdleglosc(Point innyPkt)
        {
            double deltaX = innyPkt.X - this.X;
            double deltaY = innyPkt.Y - this.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }

            

               
        
        internal class Program
    
        static void Main(string[] args)
        {
            //zad.1 cd.

            // Tworzenie instancji klasy Ksiazka
            Ksiazka ksiazka = new Ksiazka("Fantastyka", 2021);

            // Wyswietlanie informacji o ksiazce
            ksiazka.WyswietlInformacje();

            //zad.2 cd
            // Tworzenie produktow
            Produkt produkt1 = new Produkt("Jabłko", 2.50m);
            Produkt produkt2 = new Produkt("Chleb", 3.00m);
            Produkt produkt3 = new Produkt("Mleko", 2.20m);

            // Tworzenie listy produktow
            List<Produkt> listaProduktow = new List<Produkt> { produkt1, produkt2, produkt3 };

            // Tworzenie koszyka
            Koszyk koszyk = new Koszyk(listaProduktow);

            // Wyswietlanie produktw i sumy cen
            koszyk.WyswietlProdukty();

            //zad.3 cd.
            Sklep sklep = new Sklep(3);

            Klient klient1 = new Klient("x", 1);
            Klient klient2 = new Klient("y", 2);
            Klient klient3 = new Klient("z", 3);
            Klient klient4 = new Klient("q", 4); //dodatkowy klient

            sklep.DodKlienata(klient1);
            sklep.DodKlienata(klient2);
            sklep.DodKlienata(klient3);
            sklep.DodKlienata(klient4); //proba dodania 4 klienta

            sklep.WyswietlKlientow();
            Console.WriteLine($"Liczba klientow: {sklep.LiczbaKlientow}");

            //zad.4 cd
            Point punkt1 = new Point(6.0, 9.0);

            //generowanie "losowych" wspolrzednych 2 pkt
            Random random = new Random();
            double losowyX = random.NextDouble() * 10;
            double losowyY = random.NextDouble() * 10;
            Point punkt2 = new Point(losowyX, losowyY);

            //obl odleglosci
            double odleglosc = punkt1.OblOdleglosc(punkt2);
            Console.WriteLine($"Odleglosc miedzy punktami: {odleglosc}");




         }   
 

}
