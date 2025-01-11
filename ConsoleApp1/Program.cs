using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace ConsoleApp1

//zajecia 11.01.2025
{
    //zad.1
    class Ksiazka
    {
        public string Gatunek;
        public int RokWydania;

        public Ksiazka()
        {
            Gatunek = "Nieznany";
            RokWydania = 0;
        }
        
         
     }

    //zad.2
    class Produkt
    { public string Nazwa {  get; set; }
        public float Cena { get; set; }

        public Produkt(string nazwa, decimal cena) 
        {
            Nazwa = nazwa;
            Cena = cena;
        
        
        }
        public override string ToString()
        {
            return $"{Nazwa}: {Cena}";
        }

    }

    class Koszyk
    {
        public List<Produkt> Produkty { get; private set; }
        public decimal SumaCen {  get; private set; }

        public Koszyk(List<Produkt> produkty)
        {
            Produkty = produkty;
            SumaCen = ObliczSumeCen();
        }

        private decimal ObliczSumeCen()
        {
            decimal suma = 0;
            foreach (var produkt in Produkty)
            {
                suma += produkt.Cena;
            }
            return suma;
        }

        public override string ToString()
        {
            string produktyStr = string.Join(Environment.NewLine, Produkty);
            return $"Produkty w koszyku: \n{produktyStr}\n Suma cen: {SumaCen} PLN";
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
            Ksiazka mojaKsiazka = new Ksiazka();
            Console.WriteLine($"Gatunek: {mojaKsiazka.Gatunek} , Rok wydania: {mojaKsiazka.RokWydania}");

            //zad.2 cd
            Produkt produkt1 = new Produkt("Jabłko", 2.50m);
            Produkt produkt2 = new Produkt("Chleb", 3.00m);
            Produkt produkt3 = new Produkt("Mleko", 2.20m);

            Koszyk koszyk = new Koszyk(new List<Produkt> { produkt1, produkt2, produkt3 });
            Console.WriteLine(koszyk);

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
