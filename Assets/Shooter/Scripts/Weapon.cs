using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> ShootInputMethod;

    [SerializeField]
    private float attackRate;
    private float attackCooldown;

    public void Attack()
    {
        if (attackCooldown <= 0)
        {
            DoAttack();
            attackCooldown = attackRate;
        }
    }

    protected virtual void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    protected abstract void DoAttack();
}
