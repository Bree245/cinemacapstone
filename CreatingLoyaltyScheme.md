# Creating Loyalty Scheme

The loyalty scheme allows members to upgrade to Gold membership.
```csharp
public void UpgradeMemberToGold(string memberName) {
    var member = members.FirstOrDefault(m => m.Name == memberName);
    if (member != null && !(member is GoldMember)) {
        var gold = new GoldMember(member.Name);
        gold.SetVisitCount(member.VisitCount);
        members.Remove(member);
        members.Add(gold);
    }
}
```
