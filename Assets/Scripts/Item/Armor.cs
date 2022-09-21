using UnityEngine;

public class Armor : Equipment
{
    public ArmorData ArmorData { get; private set; }
    public Armor(ArmorData data) : base(data) { ArmorData = data; }
}
