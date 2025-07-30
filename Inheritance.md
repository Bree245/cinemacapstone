# Inheritance

`GoldMember` inherits from `Member` to add discount functionality.
```csharp
public class GoldMember : Member {
    public override decimal ApplyDiscount(decimal total) {
        return total * 0.75m;
    }
}
```
