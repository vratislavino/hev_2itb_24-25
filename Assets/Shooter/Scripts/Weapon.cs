using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public void Attack()
    {
        // we will get here later
        DoAttack();
    }

    protected abstract void DoAttack();
}
