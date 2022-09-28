using UnityEngine;

public interface IBattle
{
    public void Attack();
    public void Defend();
    public void Damaged(float damage, Vector3 hitDir, Vector3 hitPoint);
}
