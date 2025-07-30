# Polymorphism

`ApplyDiscount` method works differently for `Member` and `GoldMember`.
```csharp
Member regular = new Member("Alice");
Member gold = new GoldMember("Bob");
Console.WriteLine(regular.ApplyDiscount(100)); // 100
Console.WriteLine(gold.ApplyDiscount(100)); // 75
```
