using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(true);

            Voorbeeld.DezeIsStatic();
            Voorbeeld instantie = new Voorbeeld();
            instantie.DezeIsNietStatic();

            Console.WriteLine(args.Length);
            
            foreach (var item in args)
            {
                int getal;
                if (int.TryParse(item, out getal))
                {
                    Console.WriteLine(getal * 2);
                }
                else
                {
                    Console.WriteLine("Verkeerde invoer: " + item);
                }
            }



            var kaart = new Kaart();
            kaart.SetKleur(Kleur.Harten);
            kaart.SetWaarde(5);

            Console.WriteLine(kaart.GetKleur());

            Print(new Driehoek { Breedte = 5, Hoogte = 12 });
            Print(new Cirkel { Diameter = 30 });

            Console.Write("Voer je leeftijd in: ");
            string leeftijd = Console.ReadLine();

            Console.WriteLine($"Je bent dus {leeftijd} jaar oud.");
        }

        /// <summary>
        /// Dit print de oppervlakte van de meegegeven vorm.
        /// </summary>
        /// <param name="i">De vorm</param>
        public static void Print(Vorm i)
        {
            Console.WriteLine("Oppervlakte: " + i.BerekenOppervlakte() + ".");
            Console.WriteLine("Oppervlakte: {0:#.####}.", i.BerekenOppervlakte());
            Console.WriteLine($"Oppervlakte: {i.BerekenOppervlakte():#.###}.");
        }
    }



    class Kaart
    {
        private Kleur _kleur;
        private int _waarde;

        public Kleur GetKleur()
        {
            return _kleur;
        }
        public void SetKleur(Kleur value)
        {
            _kleur = value;
        }


        public Kleur Kleur1
        {
            get
            {
                return _kleur;
            }
            set
            {
                _kleur = value;
            }

        }

        public Kleur Kleur2 { set; get; }

        public void SetWaarde(int waarde)
        {
            _waarde = waarde;
        }

        //public Kleur Kleur { get; set; }
        //public int Waarde { get; set; }
    }

    enum Kleur
    {
        Harten,
        Klaver,
        Schoppen,
        Ruit
    }

    interface Vorm
    {
        double BerekenOppervlakte();
    }

    class Rechthoek : Vorm
    {
        public double Lengte { get; set; }
        public double Breedte { get; set; }

        public double BerekenOppervlakte()
        {
            return Lengte * Breedte;
        }
    }

    class Driehoek : Vorm
    {
        public double Breedte { get; set; }
        public double Hoogte { get; set; }

        public double BerekenOppervlakte()
        {
            return Breedte * Hoogte / 2;
        }
    }

    class Cirkel : Vorm
    {
        public double Diameter { get; set; }

        public double BerekenOppervlakte()
        {
            return Math.PI * Math.Pow(Diameter, 2) / 4;
        }
    }

    class Voorbeeld
    {
        public static void DezeIsStatic()
        {
        }


        public void DezeIsNietStatic()
        {
        }
    }
}