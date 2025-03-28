using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action AmmoChanged;
    public event Action<float> ReloadProgressChanged;

    public Func<string, bool> ShootInputMethod;

    [SerializeField]
    private float attackRate;
    private float attackCooldown;

    public virtual int CurrentAmmo { get; }
    public virtual int MaxAmmo { get; }
    public virtual bool IsReloading { get; }

    public void Attack()
    {
        if (attackCooldown <= 0)
        {
            DoAttack();
            attackCooldown = attackRate;
        }
    }

    public virtual void Reload() { }

    protected void RaiseAmmoChanged()
    {
        AmmoChanged?.Invoke();
    }

    protected void RaiseReloadProgressChanged(float progress)
    {
        ReloadProgressChanged?.Invoke(progress);
    }


    protected virtual void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    protected abstract void DoAttack();
}
