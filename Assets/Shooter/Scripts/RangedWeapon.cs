using UnityEngine;
using UnityEngine.Video;

public abstract class RangedWeapon : Weapon
{ // reloading
    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    private int maxAmmo;
    private int currentAmmo;

    [SerializeField]
    protected Rigidbody bulletPrefab;

    [SerializeField]
    protected Transform bulletSpawnPoint;

    [SerializeField]
    protected float reloadTime;
    private float remainingReloadTime;

    public override int CurrentAmmo => currentAmmo;
    public override int MaxAmmo => maxAmmo;
    public override bool IsReloading => remainingReloadTime > 0;

    protected virtual void Start()
    {
        ShootInputMethod = Input.GetButtonDown;
        ChangeAmmo(maxAmmo);
    }

    protected override void Update()
    {
        base.Update();

        if(remainingReloadTime > 0)
        {
            remainingReloadTime -= Time.deltaTime;
            RaiseReloadProgressChanged(remainingReloadTime / reloadTime);
            if (remainingReloadTime <= 0)
            {
                ChangeAmmo(maxAmmo);
            }
        }
    }

    private void ChangeAmmo(int ammo)
    {
        currentAmmo = ammo;
        RaiseAmmoChanged();
    }

    public override void Reload()
    {
        remainingReloadTime = reloadTime;
        RaiseReloadProgressChanged(1);
    }

    protected override void DoAttack()
    {
        if (currentAmmo > 0 && !IsReloading)
        {
            ChangeAmmo(currentAmmo - 1);
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        var bullet = Instantiate(
            bulletPrefab, 
            bulletSpawnPoint.position,
            bulletSpawnPoint.rotation
            );

        bullet.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        
        Destroy(bullet.gameObject, 3);
    }
}
