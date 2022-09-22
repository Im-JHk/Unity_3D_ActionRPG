using UnityEngine;

[CreateAssetMenu(fileName = "ArmorData", menuName = "ScriptableObject/ArmorData")]
public class ArmorData : EquipmentData
{
    [SerializeField]
    private int defencePower;
    public int DefencePower { get { return defencePower; } }

    public override Item CreateItem() { return new Armor(this); }
    public override int GetItemValue() { return defencePower; }
    public override string GetItemValueToString() { return string.Format("DEF +{0}", defencePower); }
}
