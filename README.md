# .NET/C# API Case

## Inhoudsopgave

<br>

## Table of contents
* [Opstarten en Gebruiken](#opstarten-en-gebruiken)
* [Trots](#trots)
* [Minder Trots](#minder-trots)

<br>

## Opstarten en Gebruiken

1. Clone het project
2. open het project in visual studio 2019
3. Run het project (Debug, Any CPU, API Case)

![screenshot](/_images/Screenshot_1.png)

* als je geen zin hebt om het project lokaal te draaien: [live demo](https://sbcase.dannycao.io/swagger/index.html)

<br>

## Trots

* mooie scheiding tussen DAL en Controllers
* deel 3 : afstand berekenen tussen twee adressen werkt :) 

<br>

## Minder Trots

* Filter werkt niet goed, je kan namelijk niet op meerdere attributen filteren in een keer.
* Sorteren werkt ook niet goed, je kan net als bij de filter niet op meerdere attributen sorteren in een keer.

Ik was van plan [Odata](https://www.odata.org/) te implementeren, maar dat was denk ik niet de bedoeling


<br>

* Afstand berekenen implementatie is niet heel netjes gedaan. Ik probeerde het met [Flurl](https://flurl.dev/) te implementeren, maar ik liep vast met de flurl query params en kon er verder niks over vinden
* GeolocationController gebruikt webclient en ik "open/dispose" in een methode, maar ik had het beter kunnen dependency injecten en kunnen scheiden in een aparte service class. 

* Helemaal geen unittesten geschreven. Ik moet werken dus geen tijd meer :(