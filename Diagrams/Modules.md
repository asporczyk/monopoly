# Diagram modułów
```mermaid
flowchart LR
    Web[Moduł interfejsu użytkownika - Vue.js]
    CommunicationHub[Moduł komunikacji z serwerem - SignalR]
    GameLogic[Moduł logiki gry - C#]
    GameManagement[Moduł zarządzania grą - C#]
    WebSocket([WebSocket])
    
    Web <--> WebSocket <--> CommunicationHub 
    
    CommunicationHub <--> GameLogic
    CommunicationHub <--> GameManagement
    
    subgraph Gra 
        GameLogic
        GameManagement
    end
    
```