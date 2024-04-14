# Diagramy sekwencji
## Rzut kostką
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameLogic as Moduł logiki gry
    
    Player ->> Web: Rzuca kostką
    Web ->> CommunicationHub: Wysyła zapytanie o rzut kostką
    CommunicationHub ->>+ GameLogic: Przekazuje zapytanie o rzut kostką
    
    Note right of GameLogic: Losuje 2x liczbę<br>od 1 do 6
    
    GameLogic ->>- CommunicationHub: Zwraca wynik rzutu kostką
    CommunicationHub ->> Web: Przekazuje wynik rzutu kostką
    Web ->> Player: Wyświetla wynik rzutu kostką
```

## Wykonanie ruchu
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    participant GameLogic as Moduł logiki gry
    
    Player ->> Web: Wykonuje ruch
    Web ->> CommunicationHub: Wysyła zapytanie o wykonanie ruchu
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o wykonanie ruchu
    
    Note right of GameManagement: Aktualizuje pozycję gracza<br>na podstawie wartości rzutu kostką
    
    GameManagement ->> GameLogic: Sprawdza czy gracz<br>przeszedł przez start
    GameLogic ->> GameManagement: Zwraca informację<br>o przejściu przez start
    
    Note right of GameManagement: Jeśli tak, to gracz<br>otrzymuje 200$ premii
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowaną planszę
```

## Kupno nieruchomości
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Kupuje nieruchomość
    Web ->> CommunicationHub: Wysyła zapytanie o kupno nieruchomości
    CommunicationHub ->>+ GameManagement: Przekazuje zapytanie o kupno nieruchomości
    
    Note right of GameManagement: Aktualizuje stan konta i nieruchomości<br>gracza
    
    GameManagement ->>- CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan konta i nieruchomości
```

## Kupno budynku
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Kupuje budynek
    Web ->> CommunicationHub: Wysyła zapytanie o kupno budynku
    CommunicationHub ->>+ GameManagement: Przekazuje zapytanie o kupno budynku
    
    Note right of GameManagement: Aktualizuje stan konta i nieruchomości<br>gracza
    
    GameManagement ->>- CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan konta i nieruchomości
```

## Płatność czynszu
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Płaci czynsz
    Web ->> CommunicationHub: Wysyła zapytanie o płatność
    CommunicationHub ->>+ GameManagement: Przekazuje zapytanie o płatność
    
    Note right of GameManagement: Aktualizuje stany kont gracza<br>który płaci<br> i gracza który otrzymuje płatność
    
    GameManagement ->>- CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowane stany kont graczy
```

## Otrzymanie karty
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    participant GameLogic as Moduł logiki gry


    Player ->> Web: Otrzymuje kartę
    Web ->> CommunicationHub: Wysyła zapytanie o otrzymanie karty
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o otrzymanie karty
    GameManagement ->>+ GameLogic: Losuje kartę
    
    Note right of GameLogic: Losuje kartę z puli kart<br>szansy lub kasy społecznej
    
    GameLogic ->>- GameManagement: Zwraca kartę
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan gry
```

## Przejście na pole Idziesz do więzienia
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    participant GameLogic as Moduł logiki gry
    
    Player ->> Web: Trafia na pole Idziesz do więzienia
    Web ->> CommunicationHub: Wysyła zapytanie o przejście na pole Idziesz do więzienia
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o przejście na pole Idziesz do więzienia
    
    Note right of GameManagement: Przenosi gracza na pole więzienia
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowaną planszę
```

## Wyjście z więzienia (płacąc grzywnę)
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Płaci grzywnę
    Web ->> CommunicationHub: Wysyła zapytanie o płatność grzywny
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o płatność grzywny
    
    Note right of GameManagement: Aktualizuje stan konta gracza<br>który płaci grzywnę<br>i aktualizuje stan gracza
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan konta
    
    Note right of Player: W następnej turze<br>gracz wykonuje ruch
```

## Wyjście z więzienia (używając karty wyjścia z więzienia)
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Używa karty wyjścia z więzienia
    Web ->> CommunicationHub: Wysyła zapytanie o użycie karty wyjścia z więzienia
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o użycie karty wyjścia z więzienia
    
    Note right of GameManagement: Usuwa kartę z ręki gracza
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowane karty gracza

    Note right of Player: W następnej turze<br>gracz wykonuje ruch
```

## Wyjście z więzienia (bez płacenia grzywny lub karty wyjścia z więzienia)
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameLogic as Moduł logiki gry
    participant GameManagement as Moduł zarządzania grą
    
    loop 3 razy
        Player ->> Web: Rzuca kostką
        Web ->> CommunicationHub: Wysyła zapytanie o rzut kostką
        CommunicationHub ->> GameLogic: Przekazuje zapytanie o rzut kostką
        
        Note right of GameLogic: Losuje 2x liczbę<br>od 1 do 6
        
        Note right of GameLogic: Jeśli gracz rzuca dublet
        
        GameLogic ->> GameManagement: Przekazuje informację o wyrzuceniu dubletu
        
        Note right of GameManagement: Gracz wychodzi z więzienia
        
        GameManagement ->> GameLogic: Zwraca zaktualizowany stan gry
        GameLogic ->> CommunicationHub: Zwraca zaktualizowany stan gry i wynik rzutu
        CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry i wynik rzutu
        Web ->> Player: Wyświetla informację o wyjściu z więzienia i wynik rzutu

        Note right of Player: Gracz wykonuje ruch
        
        Note right of GameLogic: Jeśli gracz nie rzuca dublet
        
        GameLogic ->> CommunicationHub: Zwraca informację o braku dubletu i wynik rzutu
        CommunicationHub ->> Web: Przekazuje informację o braku dubletu i wynik rzutu
        Web ->> Player: Wyświetla informację o braku dubletu i wynik rzutu
        
        Note right of Player: Gracz czeka w więzieniu<br>na kolejną turę
    end
    
    Player ->> Web: Płaci grzywnę
    Web ->> CommunicationHub: Wysyła zapytanie o płatność grzywny
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o płatność grzywny
    
    Note right of GameManagement: Aktualizuje stan konta gracza<br>który płaci grzywnę<br>i aktualizuje stan gracza

    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan konta

    Note right of Player: W następnej turze<br>gracz wykonuje ruch
    
```

## Zatrzymanie się na darmowym parkingu
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Zatrzymuje się na darmowym parkingu
    Web ->> CommunicationHub: Wysyła zapytanie o zatrzymanie się na darmowym parkingu
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o zatrzymanie się na darmowym parkingu
    
    Note right of GameManagement: Gracz jest blokowany<br> a jedną turę
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowaną planszę
```

## Bankructwo
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Bankrutuje, gdy nie ma pieniędzy
    Web ->> CommunicationHub: Wysyła zapytanie o bankructwo
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o bankructwo
    
    Note right of GameManagement: Usuwa gracza z gry
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan gry
```

## Sprzedaż nieruchomości
```mermaid
sequenceDiagram
    actor Player as Gracz
    participant Web as Moduł interfejsu użytkownika
    participant CommunicationHub as Moduł komunikacji z serwerem
    participant GameManagement as Moduł zarządzania grą
    
    Player ->> Web: Sprzedaje nieruchomość
    Web ->> CommunicationHub: Wysyła zapytanie o sprzedaż nieruchomości
    CommunicationHub ->> GameManagement: Przekazuje zapytanie o sprzedaż nieruchomości
    
    Note right of GameManagement: Aktualizuje stan konta gracza<br>który sprzedaje nieruchomość<br>i aktualizuje stan gracza<br>który kupuje nieruchomość
    
    GameManagement ->> CommunicationHub: Zwraca zaktualizowany stan gry
    CommunicationHub ->> Web: Przekazuje zaktualizowany stan gry
    Web ->> Player: Wyświetla zaktualizowany stan konta graczy<br> i stan posiadanych nieruchomości
```