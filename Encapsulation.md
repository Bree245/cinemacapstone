# Encapsulation

Encapsulation is used to protect member data.
```csharp
public class Member {
    public string Name { get; private set; }
    public int VisitCount { get; private set; }
}
```
Properties are private set to avoid external modification.
