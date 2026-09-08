using System.Text;
using System.Threading.Tasks;

namespace Text_Based_adventure
{
    internal class Program
    {
        // Deze drie velden zijn de complete spelstatus. Ze staan static
        // omdat alle methodes in deze klasse eraan moeten kunnen.
        static Dictionary<string, Scene> scenes = Verhaal.MaakScenes();
        static string huidig = "ingang";
        static List<string> tas = new List<string>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MainMenu();
        }

        static void MainMenu()
        {
            // While-lus zodat de speler na een potje terugkomt in het menu
            // in plaats van dat het programma afsluit.
            bool draait = true;

            while (draait)
            {
                ToonTitelscherm();
                string keuze = LeesInvoer();

                if (keuze == "start")
                {
                    huidig = "ingang";
                    tas = new List<string>();
                    Speel();
                }
                else if (keuze == "laden")
                {
                    if (Laden())
                    {
                        Speel();
                    }
                }
                else if (keuze == "help")
                {
                    Help();
                    Wacht();
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
                        PakItemOp(scene, invoer);
                        huidig = scene.Keuzes[invoer];
                        Console.Clear();
                        ToonScene();
                    }
                    else if (invoer == "kijk")
                    {
                        Console.Clear();
                        ToonScene();
                    }
                    else if (invoer == "help")
                    {
                        Help();
                    }
                    else if (invoer == "doel")
                    {
                        ToonDoel();
                    }
                    else if (invoer == "hint")
                    {
                        Console.WriteLine("\n  " + scene.Hint + "\n");
                    }
                    else if (invoer == "tas")
                    {
                        ToonTas();
                    }
                    else if (invoer == "opslaan")
                    {
                        Opslaan();
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

            // Spelers typen het woord vaak mét haakjes over: [praat]
            return invoer.Trim().ToLower().Trim('[', ']').Trim();
        }

        static void Wacht()
        {
            // Buffer legen: anders vangt ReadKey een toets op die als commando bedoeld was
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.WriteLine("(Druk op een toets om verder te gaan)");
            Console.ReadLine();
        }
        static void ToonDoel()
        {
            int akt = scenes[huidig].Akt;

            Console.WriteLine();
            if (akt == 1)
            {
                Console.WriteLine("  DOEL: Bereik de serverkelder onder Datacentrum Zuid.");
            }
            else if (akt == 2)
            {
                Console.WriteLine("  DOEL: Vind het beheerderswachtwoord van dr. Halberd.");
            }
            else
            {
                Console.WriteLine("  DOEL: Beslis wat er met NEXUS gebeurt.");
            }
            Console.WriteLine();
        }

        static void Help()
        {
            Console.WriteLine("""

                --- HOE JE SPEELT ---
                Je typt commando's. Enter om te bevestigen.

                  kijk       omgeving opnieuw beschrijven
                  doel       je huidige missie tonen
                  hint       aanwijzing als je vastzit
                  tas        je inventaris bekijken
                  opslaan    voortgang bewaren
                  stop       terug naar het menu

                Bij keuzes typ je het woord tussen [haakjes],
                dus 'praat' en niet '[praat]'.
                NEXUS luistert mee. Het onthoudt wat je kiest.

                """);
        }
        static void PakItemOp(Scene scene, string invoer)
        {
            if (scene.ItemBijKeuze.ContainsKey(invoer))
            {
                string item = scene.ItemBijKeuze[invoer];

                if (tas.Contains(item) == false)
                {
                    tas.Add(item);
                    Console.WriteLine("\n[Je hebt nu: " + item + "]");
                    Wacht();
                }
            }
        }

        static void ToonTas()
        {
            Console.WriteLine();
            if (tas.Count == 0)
            {
                Console.WriteLine("  Je tas is leeg.");
            }
            else
            {
                Console.WriteLine("  In je tas:");
                foreach (string item in tas)
                {
                    Console.WriteLine("   - " + item);
                }
            }
            Console.WriteLine();
        }

        static void Opslaan()
        {
            // Regel 1 is de scene, alle regels daarna zijn items uit de tas
            List<string> regels = new List<string>();
            regels.Add(huidig);

            foreach (string item in tas)
            {
                regels.Add(item);
            }

            File.WriteAllLines("save.txt", regels);
            Console.WriteLine("\n[Voortgang opgeslagen. NEXUS heeft een kopie bewaard.]\n");
        }

        static bool Laden()
        {
            if (File.Exists("save.txt") == false)
            {
                Console.WriteLine("\n[Geen opgeslagen sessie gevonden.]\n");
                Wacht();
                return false;
            }

            string[] regels = File.ReadAllLines("save.txt");

            if (regels.Length == 0 || scenes.ContainsKey(regels[0]) == false)
            {
                Console.WriteLine("\n[Opgeslagen bestand is beschadigd.]\n");
                Wacht();
                return false;
            }

            huidig = regels[0];
            tas = new List<string>();

            for (int i = 1; i < regels.Length; i++)
            {
                tas.Add(regels[i]);
            }

            Console.WriteLine("\n[Sessie hervat. Je was weg. Ik niet.]\n");
            Wacht();
            return true;
        }
    }
}