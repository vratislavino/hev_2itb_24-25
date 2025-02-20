using UnityEngine;
using UnityEngine.Video;

public abstract class RangedWeapon : Weapon
{ // reloading
    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private int maxAmmo;
    private int currentAmmo;

    [SerializeField]
    private Rigidbody bulletPrefab;

    [SerializeField]
    private Transform bulletSpawnPoint;

    protected virtual void Start()
    {
        ShootInputMethod = Input.GetButtonDown;
        currentAmmo = maxAmmo;
    }

    protected override void DoAttack()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
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
