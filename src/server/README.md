# Serwer zaplecza Monopoly

To jest serwer zaplecza do gry Monopoly. Napisany jest w .NET 8 i korzysta z funkcji minimalnego API dla implementacji serwera. Serwer wykorzystuje także SignalR do komunikacji z graczami.

## Pierwsze kroki

Aby rozpocząć pracę z serwerem zaplecza Monopoly, wykonaj następujące kroki:

1. Sklonuj repozytorium: `git clone https://github.com/asporczyk/monopoly`
2. Przejdź do katalogu serwera: `cd monopoly/src/server`
3. Zainstaluj wymagane zależności: `dotnet restore`
4. Zbuduj serwer: `dotnet build`
5. Uruchom serwer: `dotnet run`

## Funkcje

- Implementacja minimalnego API dla lekkiej i efektywnej obsługi serwera.
- Integracja z SignalR umożliwiająca komunikację w czasie rzeczywistym z graczami.
- Obsługa i serwowanie logiki gry Monopoly.
