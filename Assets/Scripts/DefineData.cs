namespace NS_Unit
{
    public enum UnitType
    {
        Player = 0,
        Monster
    }
    public enum AnimatorLayer
    {
        Base = 0,
        Blend,
        Single
    }
    public enum BaseState
    {
        Idle = 0,
        Walk,
        Run,
        Attack,
        Defend,
        Dodge,
        Die
    }
    public enum MoveState
    {
        None = 0,
        Idle,
        Walk,
        Run
    }
    public enum ActionState
    {
        None = 0,
        Attack,
        Defend,
        Dodge,
        Die
    }
}

namespace NS_Phase
{
    public enum PhaseType
    {
        RushAttack = 0,
        MeleeAttack,
        StandoffAttack,
        Defend
    }
}

public enum TrueFalse
{
    False = 0,
    True
}

public enum EventType
{
    OnGameover = 0,
    OnLevelup,
    OnAttack,
    OnDamage,
    OnDie
}

public enum StatPointType
{
    Hp = 0,
    Mp,
    ATK,
    DEF
}

public enum ItemType
{
    Normal = 0,
    Equipable,
    Consumable,
}

public enum EquipmentType
{
    Weapon = 0,
    SubWeapon,
    Accessory,
    Head,
    Body,
    Foot
}

public enum EquipedValueType
{
    Atk = 0,
    Def
}