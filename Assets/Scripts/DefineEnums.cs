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
        Dodge
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
