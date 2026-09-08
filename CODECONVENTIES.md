# Codeconventies

Text-Based Adventure - NEXUS
Rowan de Bont



## Waarom conventies

Conventies zijn afspraken over hoe code eruitziet. Ze zorgen ervoor dat code voorspelbaar blijft, ook als je er een week niet naar hebt gekeken of als iemand anders eraan verder werkt. Ik merkte dat zelf toen ik een methode die ik op 7 september had geschreven een dag later opnieuw moest uitzoeken. Hieronder staan de afspraken die ik in dit project heb aangehouden.


## 1. Naamgeving

PascalCase voor classes, methodes en properties. Bijvoorbeeld Scene, ToonScene(), Beschrijving.

camelCase voor lokale variabelen en velden. Bijvoorbeeld huidig, invoer, scenes.

Alle namen zijn Nederlands, omdat de inhoud van het spel dat ook is. Ik meng geen talen binnen een naam.

Een methode begint met een werkwoord dat zegt wat hij doet: ToonTas(), LeesInvoer(), PakItemOp().

Geen afkortingen. Ik schrijf beschrijving en niet beschr. Een naam mag lang zijn als hij daardoor duidelijk is.


## 2. Indeling van bestanden

Elke class staat in een eigen bestand met dezelfde naam als de class. De namespace is gelijk aan de projectnaam.

Ik heb data en logica bewust gescheiden:

Scene.cs bevat alleen data. Het beschrijft welke velden een scene heeft en bevat geen logica.

Verhaal.cs bevat alleen inhoud. Alle scenes van het spel staan hier als data. Een scene toevoegen betekent hier een regel bijzetten.

Program.cs bevat alleen logica. Het menu, de game loop, de weergave en het opslaan.

Door die scheiding kan het verhaal groeien zonder dat de logica verandert.


## 3. Methodes

Een methode doet een ding en heeft een naam die dat dekt. Als een methode langer wordt dan ongeveer twintig regels, splits ik hem.

Weergave, invoer en opslag staan bij mij in aparte methodes. ToonScene, ToonTas en ToonDoel voor weergave. LeesInvoer en Wacht voor invoer. Opslaan en Laden voor opslag.


## 4. Opmaak

Vier spaties per inspringniveau. Ik formatteer met Ctrl+K, Ctrl+D in Visual Studio.

Altijd accolades bij if en else, ook bij een regel. Dat voorkomt fouten bij het uitbreiden.

Openende accolade op een eigen regel, zoals gebruikelijk in C#.

Meerdere regels tekst schrijf ik als raw string literal met drie aanhalingstekens, niet met \r\n.

Een witregel tussen blokken die iets anders doen. Geen witregels midden in een gedachte.


## 5. Commentaar

Commentaar legt uit waarom iets zo is gedaan, niet wat er staat. Wat er staat kun je lezen, waarom het zo bedacht is niet. Ik schrijf geen commentaar bij code die zichzelf uitlegt.

Niet doen:

    // verhoog i met 1
    i++;

Wel doen:

    // Een scene zonder keuzes is een eindscene. Dat leiden we af uit de
    // data zelf, zodat we geen aparte lijst met eindes hoeven bij te houden.
    if (scene.Keuzes.Count == 0)


## 6. Git

Per commit een afgeronde wijziging. Niet drie losse dingen in een keer.

Commitberichten in gebiedende wijs, kleine letter, Nederlands. Bijvoorbeeld: voeg opslaan naar tekstbestand toe.

De mappen bin en obj horen niet in de repository. Die staan in .gitignore.


## 7. Wat ik nog wil verbeteren

De methode Speel() is nog te lang. Daarin zitten zowel de game loop als alle commando's. Die wil ik verder opsplitsen.

Ik wil de conventies consequenter toepassen, want nu hanteer ik ze niet overal even strikt.

Verhaal.cs heeft nog geen commentaar.
