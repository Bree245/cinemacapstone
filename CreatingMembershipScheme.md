# Creating Membership Scheme

Members are represented by the `Member` class and may be upgraded to `GoldMember`.
```csharp
public class Member {
    public string Name { get; set; }
    public int VisitCount { get; private set; }
}
```
