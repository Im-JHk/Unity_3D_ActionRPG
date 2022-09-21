using UnityEngine;

public class Weapon : Equipment
{
    public WeaponData WeaponData { get; private set; }
    public Weapon(WeaponData data) : base(data) { WeaponData = data; }
}
