# Kino
Projekt - Aplikacje backendowe

Założeniem projektu jest wykonanie aplikacji opartej na schemacie kina. Dostęp do aplikacji mają Użytkownicy i Administratorzy. Każdy z nich ma odpowiednia rolę dzięki czemu Administrator ma najwięcej uprawnień między innymi dodawania kin i biletów bądź usuwania a użytkownik jedynie do wyświetlania pod warunkiem że każdy z nich jest zalogowany. Dzięki użyciu tokena JWT autoryzowany jest każdy użytkownik. Cały projekt został wykonany w programie Visual Studio 2019 wykorzystując platformę ASP.NET Core i oprogramowanie pośredniczące Ocelot.
Kontrolery mają wspólną bazę danych. Gateway otrzymuje zapytanie które następnie przesyłane jest do odpowiedniego kontrolera. Następnie model mapuje dane z bazy które są przesyłane z powrotem do API.
Uruchamianie aplikacji:
1.Potrzebujemy programu Visual Studio 2019 w którym zainstalujemy następujące pakiety NuGet:
•	AutoMapper, 
•	AutoMapper.Extensions.Microsoft.DependencyInjection, 
•	FluentValidation, 
•	FluentValidation.AspNetCore, 
•	Microsoft.AspNetCore.Authentication.JwtBearer, 
•	Microsoft.EntityFrameworkCore, 
•	Microsoft.EntityFrameworkCore.Design, 
•	Microsoft.EntityFrameworkCore.SqlServer, 
•	Microsoft.EntityFrameworkCore.Tools, 
•	Microsoft.Extensions.Identity.Core, 
•	Microsoft.VisualStudio.Web.CodeGeneration.Design,
•	Ocelot,
•	Ocelot.Cache.CacheManager, 
•	Swashbuckle.AspNetCore
2.Po zainstalowaniu wszystkich pakietów należy w projekcie wybrać  properties>Startup Project i ustawić wartość „Multiple startup projects”.
3.Następnie uruchamiamy aplikacje przyciskiem „Start”.


Sekwencja wykonywanych działań:
1.	Analiza wymagań
2.	Stworzenie schematu 
3.	Utworzenie repozytorium na GitHub
4.	Utworzenie modeli Kina, Filmów i Użytkownika
5.	Stworzenie kontrolerów
6.	Seedowanie danych do bazy
7.	Wstrzykiwanie zależności w kontrolerach ASP.NET Core i interfejsu API
8.	Ustawienia mapowania danych
9.	Generowanie metadanych struktury Swagger interfejsu API przy użyciu pakietu NuGet swashbuckle
10.	Dodanie autentykacji
11.	Dodanie autoryzacji
12.	Dodanie walidacji danych
13.	Ustawienia dot. komunikacji miedzy mikroserwisami
14.	Testowanie
15.	Naprawa błędów
16.	Napisanie dokumentacji projektu


