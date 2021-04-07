Ons voorstel is om een simpele vorm te maken van het computerspel Voetbal Simulator “Hands-off”. De applicatie zal volledig in UWP worden ontwikkeld. In de simulator is de speler een voetbaltrainer van een voetbalteam. Als voetbaltrainer kan de speler een voetbalteam aanmaken. De speler heeft zelf de leiding over de attributen van de spelers in het voetbalteam. 

Onze versie zal zich meer richten op het simulatie-gedeelte van de game. Hoe ver een game berekend is, zal worden getoond aan de speler door middel van een percentage. De game zal niet visueel worden getoond door middel van animaties aan de speler. Via een Text-based GUI wordt de status van de simulatie getoont aan de speler. 

1-100 games kunnen achter elkaar gesimuleerd worden. Het is aan de speler hoeveel games er achter elkaar gespeeld zullen worden. Aan het einde van de simulatie krijgt de speler een scherm getoond met de resultaten. Er wordt getoond:

Hoeveel games er gewonnen/verloren zijn;
De doelpunten die door beide voetbalteams gemaakt zijn;

Alle gegenereerde gegevens worden in een database opgeslagen. Hierdoor kunnen de gegevens later bekeken worden door de speler.
MoSCoW
Must have
Gesimuleerde voetbal matches;
Meerdere voetbal matches tegelijkertijd;
Unieke spelers attributen;
Voetbalteams die de speler zelf samen kan stellen.
Individuele progress bars voor elke match;
Een progress-bar voor de vordering van alle voetbal matches bij elkaar.

Should have
Match geschiedenis;
Een abort knop;
Loading screen;
Voetbalteams opslaan en laden als CSV bestandsformaat;
Splash screen.


Could have
Een voetbalteam generator knop;
Home screen;
Het genereren van de straf kaarten die zijn uitgedeeld;
Het genereren van de blessures die zijn opgelopen.

Won’t have
Geanimeerde matches;
Geanimeerde sprites.

Waar threading en hoe
Simulaties tegelijkertijd laten lopen
Hier wordt de Threadpool voor gebruikt. Hierdoor kunnen verschillende simulaties tegelijkertijd uitgevoerd en beheerd worden. Door meerdere voetbal matches uit te voeren kan de gemiddelde winkans van een match berekend worden. Hier zouden ook verschillende matches tegelijk in uitgevoerd kunnen worden om te zien tegen welk team er het meeste kans maakt om te winnen.
Database
De gegenereerde gegevens worden naar een database toegeschreven. De gegevens kunnen opgehaald worden en worden getoond in een overzicht. Schrijven naar en lezen van de database zal asynchroon gebeuren door middel van Plinq. De database variant die we gaan toepassen is SQLite. SQLite is een SQL-gebaseerde relational database. 
Window zelf
Tijdens de simulatie van een match wordt het overzicht van gespeelde wedstrijden automatisch aangevuld zodra deze in de achtergrond zijn uitgevoerd en uitgespeeld zijn. De speler kan in het overzicht zien hoeveel tijd er nog in de simulatie gespeeld moet worden.
