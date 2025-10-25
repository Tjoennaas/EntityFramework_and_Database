

/*
Endepunkter

POST /recipes – opprett oppskrift
GET /recipes/{id} – hent én
GET /recipes – filtrer på ?tag=vegan

Validering
Name (påkrevd, 3–100 tegn)
Ingredients (minst 1)
Steps (minst 1, maks 50)

Exception handling

Når {id} ikke finnes → returner 404 med { traceId, message }.

Logging (Serilog)

Information når ny oppskrift opprettes (med oppskrifts-id).
Warning ved tomt filtertreff.
Error ved uventede exceptions.
*/