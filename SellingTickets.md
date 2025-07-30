# Selling Tickets

Tickets are sold using the `SellTransaction` method.
```csharp
decimal ticketPrice = isPremium ? screening.PremiumPrice : screening.StandardPrice;
ISellable ticket = new Ticket(screening.MovieName, ticketPrice, isPremium);
```
