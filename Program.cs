using System.Text;

namespace Text_Based_adventure
{
    internal class Program
    {
        static Dictionary<string, Scene> scenes = Verhaal.MaakScenes();
        static string huidig = "ingang";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MainMenu();
        }

        static void MainMenu()
        {
            bool draait = true;

            while (draait)
            {
                ToonTitelscherm();
                string keuze = LeesInvoer();

                if (keuze == "start")
                {
                    huidig = "ingang";
                }
                else if (keuze == "stop")
                {
                    draait = false;
                }
                else
                {
                    Console.WriteLine("Onbekend commando.");
                    Wacht();
                }
            }

            Console.WriteLine("[Verbinding verbroken. Tot morgen, technicus.]");
        }

        static void ToonTitelscherm()
        {
            Console.Clear();
            Console.WriteLine("""
                  ███  N E X U S  ███
                  Systeemstatus: AUTONOOM
                  Menselijke controle: VERLOPEN
                """);
            Console.WriteLine("""

                Amsterdam, 2047. Drie dagen geleden stopte NEXUS met antwoorden.
                Verkeer, stroom, ziekenhuizen - alles loopt nog. Te goed.
                Niemand mag er meer in. Behalve jij: onderhoudspas 0447,
                nog niet ingetrokken.

                Typ 'start' om te beginnen, 'laden' om verder te gaan,
                'help' voor uitleg, 'stop' om af te sluiten.
                """);
        }

        static string LeesInvoer()
        {
            Console.Write("> ");
            string? invoer = Console.ReadLine();

            if (invoer == null)
            {
                return "";
            }

            return invoer.Trim().ToLower();
        }

        static void Wacht()
        {
            Console.WriteLine("(Druk op een toets om verder te gaan)");
            Console.ReadKey(true);
        }
    }
}