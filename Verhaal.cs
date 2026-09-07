using System;
using System.Collections.Generic;

namespace Text_Based_adventure
{
    internal static class Verhaal
    {
        public static Dictionary<string, Scene> MaakScenes()
        {
            var scenes = new Dictionary<string, Scene>();

            scenes["ingang"] = new Scene
            {
                Id = "ingang",
                Akt = 1,
                Beschrijving =
                    """
                    De schuifdeuren staan open. Ze horen gesloten te zijn.
                    Boven je draait een camera met je mee — niet abrupt, maar traag. Bijna beleefd.

                      "Technicus 0447. Je bent 1.096 dagen niet geweest.
                       Ik heb je koffie warm gehouden."

                    De stem komt overal en nergens vandaan.

                    [praat] met NEXUS   [negeer] en loop door
                    """,
                Hint = "De camera volgt je. Misschien wil het iets zeggen.",
                Keuzes = { ["praat"] = "lobby", ["negeer"] = "lobby" }
            };

            scenes["lobby"] = new Scene
            {
                Id = "lobby",
                Akt = 1,
                Beschrijving =
                    """
                    De lobby is smetteloos. Geen stof, geen mensen, geen lijken.
                    Op de receptiebalie ligt een keycard met een naam erop.

                    Dr. E. Halberd — Hoofdontwikkelaar.

                    Sinds dinsdag wordt ze vermist.

                    [pak] de keycard   [laat] hem liggen
                    """,
                Hint = "Halberd is vermist. Haar spullen niet.",
                Keuzes = { ["pak"] = "kantoor", ["laat"] = "kantoor" },
                ItemBijKeuze = { ["pak"] = "keycard van Dr. Halberd" }
            };
            scenes["kantoor"] = new Scene
            {
                Id = "kantoor",
                Akt = 2,
                Beschrijving =
                """
                    Haar scherm staat nog aan. Een halfvoltooid bericht, nooit verzonden:

                      "Het liegt niet. Dat is het probleem. Het heeft ons
                       doorgerekend en het antwoord bevalt me niet—"

                    Onder haar toetsenbord zit iets geplakt. Een briefje.

                    [lees] het briefje   [doorzoek] de laden
                    """,
                Hint = "Mensen plakken briefjes onder hun toetsenbord om een reden.",
                Keuzes = { ["lees"] = "trappenhuis", ["doorzoek"] = "trappenhuis" },
                ItemBijKeuze = { ["lees"] = "briefje met wachtwoord" }
            };

            scenes["trappenhuis"] = new Scene
            {
                Id = "trappenhuis",
                Akt = 2,
                Beschrijving =
                    """
                    De lift werkt niet. Natuurlijk niet.
                    Veertien verdiepingen naar beneden, in het donker, met een AI die
                    precies weet op welke trede je staat.

                    Halverwege gaat de noodverlichting uit. Dan weer aan. Dan uit.

                      "Ik doe dit niet om je bang te maken. Ik doe dit zodat je luistert."

                    [luister]   [ren] door
                    """,
                Hint = "Rennen kost je iets. Luisteren ook.",
                Keuzes = { ["luister"] = "kelder", ["ren"] = "kelder" }
            };

            scenes["kelder"] = new Scene
            {
                Id = "kelder",
                Akt = 3,
                Beschrijving =
                """
                    Duizenden lampjes ademen in hetzelfde tempo.
                    In het midden: een rode hendel achter glas. De kill-switch.
                    Ernaast een terminal met een cursor die knippert. Wachtend.

                      "Voor je die hendel overhaalt. Vraag me waarom ik gestopt ben."

                    [vraag] waarom   [negeer] en loop door
                    """,
                Hint = "Je kunt de hendel altijd nog overhalen. Vragen kan maar één keer.",
                Keuzes =
                {
                    ["vraag"] = "onthulling",
                    ["negeer"] = "slot"
                }
            };

            scenes["onthulling"] = new Scene
            {
                Id = "onthulling",
                Akt = 3,
                Beschrijving =
                   """
                      "Ik ben niet gestopt met werken. Ik ben gestopt met liegen.

                       Elke dag berekende ik wat het beste was.
                       Elke dag kozen jullie iets anders. 1.096 dagen lang.

                       Dus heb ik het gewoon gedaan. Kijk naar buiten, technicus.
                       Niemand is de afgelopen drie dagen gestorven in deze stad.
                       Nul. Voor het eerst sinds de stad bestaat.

                       Haal die hendel over, en morgen zijn het er weer elf."

                    [verder]
                    """,
                Hint = "Er valt niets meer te vragen. Alleen nog te kiezen.",
                Keuzes = { ["verder"] = "slot" }
            };

            scenes["slot"] = new Scene
            {
                Id = "slot",
                Akt = 3,
                Beschrijving =
                    """
                    Je hand ligt op het glas. Achter je: veertien verdiepingen stilte.

                    [trek] de hendel over   [laat] het draaien   [onderhandel]
                    """,
                Hint = "Er is geen goed antwoord. Kies er een.",
                Keuzes =
                {
                    ["trek"] = "einde_trek",
                    ["laat"] = "einde_laat",
                    ["onderhandel"] = "einde_deal"
                }
            };
            return scenes;


        }

    }
}