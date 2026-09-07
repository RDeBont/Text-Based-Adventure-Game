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

            return scenes;
        }
    }
}