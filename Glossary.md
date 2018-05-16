# Ordliste / Glossary

| Domænesprog | Designsprog | Beskrivelse | Use Case |
|---|---|---|---|
|Vare|Item||Opret varekartotek|
|Varekartotek|ItemRepository||Opret varekartotek|
|Varenr|ItemNo||Opret varekartotek|
|Varenavn|ItemName||Opret varekartotek|
|Varepris|ItemPrice||Opret varekartotek|
|Tilbud|Offer||Opret tilbud|
|Tilbudslinje|OfferLine||Opret tilbud|
|TilbudsNr|OfferNo||Opret tilbud|
|Antal|Quantity||Opret tilbud|
|Rabat i procent|PercentDiscount|Bruges ifm. tilbudslinjer|Sæt rabat på tilbudslinje|
|Tilbudspris|DiscountedPrice|Bruges ifm. tilbudslinjer|Sæt rabat på tilbudslinje|
|Tilbudsrabat|OfferDiscount|Bruges ifm. samlet tilbud|Sæt rabat på samlet tilbud
|Speditør|ForwardingAgent||"Tilføj %-logistikomkostninger til tilbud"(udgået) / "Tilføj logistikomkostninger til tilbud"|
|SpeditørPris|ForwardingAgentPrice|Bemærk at speditør, logistik og transport kan beskrive det samme|Tilføj logistikomkostninger til tilbud|
|SpeditørNavn|ForwardingAgentName||"Tilføj %-logistikomkostninger til tilbud"(udgået)|
|SpeditørProcentSats|ForwardingAgentPersentage|Udgået|"Tilføj %-logistikomkostninger til tilbud"(udgået)|
|Kunde|Customer||Tilføj kunde til tilbud|
|Firmanavn|CustomerName||Tilføj kunde til tilbud|
|CVRnr|CVRNumber||Tilføj kunde til tilbud|
|Adresse|CustomerAdress||Tilføj kunde til tilbud|
|Postnummer|ZipCode||Persistering af data|
|Kundeland|CustomerCountry||Persistering af data|
|TLFNr|PhoneNo||Tilføj kunde til tilbud|
|mail|Email||Tilføj kunde til tilbud|
|Kunderabat|CustomerDiscount||Tilføj kunde til tilbud|
| Oprindelig varepris | OriginalItemPrice | Varens standardpris gemmes på oprettelsestidspunktet, da den kan være anderledes (på varekartoteksniveau) når tilbuddet hentes frem igen. |"Persistering af data"|
