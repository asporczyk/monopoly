# Backend Monopoly

To jest backend do gry Monopoly. Napisany w .NET 8, wykorzystuje funkcje minimalnego API do implementacji serwera oraz SignalR do
komunikacji z graczami.

## Spis treści

1. [Pierwsze kroki](#pierwsze-kroki)
2. [Funkcje](#funkcje)
3. [Zapytania i odpowiedzi](#zapytania-i-odpowiedzi)

## Pierwsze kroki

Aby rozpocząć pracę z backendem Monopoly, wykonaj następujące kroki:

1. Sklonuj repozytorium: `git clone https://github.com/asporczyk/monopoly`
2. Przejdź do katalogu serwera: `cd monopoly/src/server`
3. Zainstaluj wymagane zależności: `dotnet restore`
4. Zbuduj serwer: `dotnet build`
5. Uruchom serwer: `dotnet run`

## Funkcje

- Implementacja minimalnego API dla lekkiej i efektywnej obsługi serwera.
- Integracja z SignalR umożliwiająca komunikację w czasie rzeczywistym z graczami.
- Obsługa i serwowanie logiki gry Monopoly.

## Zapytania i odpowiedzi

Caller — klient, który wywołuje metodę na serwerze.
All — wszyscy klienci połączeni z serwerem.
Player — wskazany przez grę gracz.
---
*Nazwa metody* -> **kto otrzymuje odpowiedź**

```json
{
  "parametr": "typ"
}
```

---

### OnConnectedAsync

*Automatyczna metoda wywoływana przy połączeniu klienta z serwerem.*
Zwracane odpowiedzi:

- *ReceiveConnectionId* -> **Caller**
    ```plaintext
    string
    ```

---

### OnDisconnectedAsync

Zwracane odpowiedzi:

- *PlayerLeft* -> **All**

  ```json 
  {
    "id": "PlayerID"
  }
  ```

---

### JoinGame

Parametry:

- `string? nickname`

Zwracane odpowiedzi:

- *PlayerJoined* -> **All**

  ```json 
  {
    "players": [
      {
        "nickname": "PlayerOne",
        "id": "12345",
        "Money": 1500,
        "Position": 0,
        "IsInJail": false,
        "JailTurns": 0,
        "IsBankrupt": false,
        "IsReady": false
      },
      ...
    ]
  }
  ```

---

### Ready

Zwracane odpowiedzi:

- *PlayerReady* -> **All**

  ```json 
  {
    "Id": "PlayerID"
  }
  ```

---

## StartGame

Zwracane odpowiedzi:

- *PlayersNotReady* -> **All**

---

- *GameAlreadyStarted* -> **All**

---

- *GameStarted* -> **All**

---

- *YourTurn* -> **Player**

---

### MovePlayer

Parametry:

- `int steps`

Zwracane odpowiedzi:

- *PlayerMoved* -> **All**

  ```json 
  {
    "Id": "PlayerID",
    "playerPosition": 5
  }
  ```

---

- *PlayerGoToJail* -> **All**

  ```json 
  {
    "Id": "PlayerID"
  }
  ```

---

- *PayIncomeTax* -> **Player**

  ```json 
  {
    "incomeTax": 123
  }
  ```

---

- *CanBuyField* -> **Player**

  ```json 
  {
    "Name": "Wall Street",
    "Price": 123
  }
  ```

---

- *PayRent* -> **Player**

  ```json 
  {
    "Nickname": "OwnerNickname",
    "Rent": 123
  }
  ```

---

- *ReceiveRent* -> **Player**

  ```json 
  {
    "Nickname": "PayedPlayerNickname",
    "Rent": 123
  }
  ```

---

- *PlayerBankrupt* -> **All**

  ```json 
  {
    "Id": "PlayerID"
  }
  ```

---

- *NextPlayer* -> **All**

  ```json 
  {
    "currentPlayerId": "PlayerID"
  }
  ```

---

- *PlayerMovedThroughGo* -> **All**

  ```json 
  {
    "Id": "PlayerID",
    "Money": 1500
  }
  ```

---

---

- *YourTurn* -> **Player**

---

### BuyField

Zwracane odpowiedzi:

---

- *FieldBought* -> **All**

  ```json 
  {
    "Id": "PlayerID",
    "Name": "Wall Street"
  }
  ```

---

### EndTurn

Zwracane odpowiedzi:

---

- *PlayerLeftJail* -> **All**

  ```json 
  {
    "Id": "PlayerID"
  }
  ```

---

- *Winner* -> **All**

  ```json 
  {
    "WinnerId": "PlayerID"
  }
  ```

---

- *NextRound* -> **All**

  ```json 
  {
    "RoundNumber": 2
  }
  ```

---

- *NextPlayer* -> **All**

  ```json 
  {
    "currentPlayerId": "PlayerID"
  }
  ```

---

- *YourTurn* -> **Player**

---

### PayBail

Zwracane odpowiedzi:

- *PlayerLeftJail* -> **All**

  ```json 
  {
    "Id": "PlayerID"
  }
  ```

---

### LeaveJail

Zwracane odpowiedzi:

- *PlayerLeftJail* -> **All**

  ```json 
  {
    "Id": "PlayerID"
  }
  ```

---

### BuyHouse

Zwracane odpowiedzi:

- *HouseBought* -> **All**

  ```json 
  {
    "Id": "PlayerID",
    "Name": "Wall Street",
    "Houses": 1
  }
  ```

---

### BuyHotel

Zwracane odpowiedzi:

- *HotelBought* -> **All**

  ```json 
  {
    "Id": "PlayerID",
    "Name": "Wall Street",
    "HasHotel": true
  }
  ```

---

### ResetGame

Zwracane odpowiedzi:

- *GameReset* -> **All**

---

### CommunityChestField

Zwracane odpowiedzi:

- *do wypełnienia*

### ChanceField

Zwracane odpowiedzi:

- *do wypełnienia*