using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/WeaponData")]
public class WeaponData : EquipmentData
{
    [SerializeField]
    private int attackPower;

    public int AttackPower { get { return attackPower; } }
    

    public override Item CreateItem()
    {
        return new Weapon(this);
    }

    public override string GetItemValueToString()
    {
        return string.Format("ATK +{0}", attackPower);
    }
}
