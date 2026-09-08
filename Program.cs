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
                    Speel();
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

        static void Speel()
        {
            bool bezig = true;

            Console.Clear();
            ToonScene();

            while (bezig)
            {
                Scene scene = scenes[huidig];

                // Geen keuzes meer = einde van het verhaal
                if (scene.Keuzes.Count == 0)
                {
                    Console.WriteLine("Druk op Enter om terug te gaan naar het menu.");
                    Console.ReadLine();
                    bezig = false;
                }
                else
                {
                    string invoer = LeesInvoer();

                    if (scene.Keuzes.ContainsKey(invoer))
                    {
                        huidig = scene.Keuzes[invoer];
                        Console.Clear();
                        ToonScene();
                    }
                    else if (invoer == "stop")
                    {
                        bezig = false;
                    }
                    else
                    {
                        Console.WriteLine("\"Dat begrijp ik niet. En ik begrijp bijna alles.\"");
                    }
                }
            }
        }

        static void ToonScene()
        {
            Scene scene = scenes[huidig];

            Console.WriteLine("[ Akt " + scene.Akt + " ]  -  typ 'help' voor commando's");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(scene.Beschrijving);
            Console.WriteLine();
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