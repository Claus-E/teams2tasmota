[English description](https://github.com/Claus-E/desktop-tutorial#english)

# teams2tasmota
a busylight for MS Teams with a tasmota device

## Kurzbeschreibung
Teams2Tasmota wertet die Logdatei von *Microsoft Teams* aus um den aktuellen Präsensstaus auf dem lokalen Rechner zu ermitteln und zu einem Busylight zu senden. Als Busylight können verschiedene Geräte auf Basis von der Quelloffenen *Tasmota*-Software eingesetzt werden. Die Übertragung der Kommandos vom PC zum Busylight erfolgt entweder über eine Serielle Schnittstelle oder IP-Basiert über LAN/WLAN.

## Features
* Software Erkennt alle Präsenszustande von Microsoft Teams
* Reine lokale Anwendung ohne Nutzung von Cloud-Diensten (z.B. Microsoft Graph Presence API)
* Es werden keine Microsoft Zugangsdaten oder besondere Berechtigungen benötigt
* Verwendung der kostenlosen Quelloffen Tasmota Firmware für ESP8266 basierte Geräte
* Geeignete Tasmota Gräte können fertig gekauft oder selbst hergestellt werden.
* Bei Verwendung von WLAN kann das Busylight ohne die Verlegung von Kabel z.B. Im Flur vor der HomeOffice Tür angebracht werden um Mitbewohner optimal zu informieren.

## Der erste Start
Teams2Tasmota.exe benötigt im gleichen Verzeichnis die config.xml und greift auf die Logdatei "%AppData%\Microsoft\Teams\logs.txt" von MS-Teams zu.

## Details

Die hier vorgestellte Software entstand, weil mit zunehmendem HomeOffice-Anteil auch der Anteil der Telefon- / Videokonferenzen stieg und damit auch Wunsch den Mitbewohnern mitzuteilen wann man gestört werden kann und wann besser nicht. Die Idee des Busylights ist ja nicht neu, aber die auf dem Markt erhältlichen Produkte und DIY-Lösungen erfüllten nicht meine Anforderungen. Ich wollte ein preiswertes Busylight, dass ich vor der Tür meines HomeOffice anbringen kann ohne dort lange Kabel hin Verlegen zu müssen. Viele andere Teams-Busylight Lösungen basieren auf der von Microsoft dafür vorgesehenen Microsoft Graph API diese wollte ich aber nicht verwenden, weil es mir unsinnig erschien, den aktuellen Zustand aus der Cloud abzurufen wenn dieser doch lokal auf dem PC schon vorhanden ist. Außerdem sind dafür auch Berechtigungen notwendig, die gegeben falls erst Admistratoren eingeräumt werden müssen. Nachdem ich dann über die Log-Datei von MS Teams gestolpert bin und gesehen habe, dass dort die Präsenzzustände immer aktuell geloggt werden habe ich eine Software in C# entwickelt die diese Auswertet und in Kommandos für die Tasmota-Firmware umsetzt. Diese Kommandos können dann entweder per USB/ComPort zur seriellen Schnittstelle des ESP 8266 übertragen werden oder per WLAN über einen WebRequest dorthin gelangen.

## Selbstbau Busylight auf Basis des ESP-01 mit WS2812 LEDring

_wird hier in Kürze beschrieben._

===

# English:
# teams2tasmota
a busylight for MS Teams with a tasmota device

## Short description
Teams2Tasmota evaluates the log file of *Microsoft Teams* to determine the current presence congestion on the local computer and send it to a Busylight. As Busylight different devices based on the open source *Tasmota* software can be used. The transmission of the commands from the PC to the Busylight is done either via a serial interface or IP-based via LAN/WLAN.

## Features
* Software recognizes all presence states of Microsoft Teams
* Pure local application without using cloud services (e.g. Microsoft Graph Presence API)
* No Microsoft credentials or special permissions required
* Use of free open source Tasmota firmware for ESP8266 based devices
* Suitable Tasmota devices can be bought ready to use or made by yourself.
* When using WLAN, the Busylight can be installed without laying cables, for example, in the hallway in front of the HomeOffice door to inform roommates optimally.

## The first start
Teams2Tasmota.exe needs config.xml in the same directory and accesses the log file "%AppData%\Microsoft\Teams\logs.txt" from MS-Teams.

## Details

The software presented here was developed because with increasing HomeOffice share also the share of telephone / video conferences increased and thus also desire to tell the roommates when you can be disturbed and when better not. The idea of the Busylight is not new, but the products and DIY solutions available on the market did not meet my requirements. I wanted an inexpensive Busylight that I could install in front of my home office door without having to run long cables to it. Many other Teams Busylight solutions are based on the Microsoft Graph API provided by Microsoft, but I didn't want to use it because it didn't make sense to me to retrieve the current status from the cloud when it is already available locally on the PC. In addition, permissions are necessary for this, which must first be granted to administrators if necessary. After I stumbled across the log file of MS Teams and saw that the presence states are always logged there, I developed a software in C# that evaluates them and converts them into commands for the Tasmota firmware. These commands can then either be transferred via USB/ComPort to the serial interface of the ESP 8266 or reach it via WLAN over a WebRequest.

## Selfmade Busylight based on ESP-01 with WS2812 LEDring

_will be described here shortly._

Translated with www.DeepL.com/Translator (free version)