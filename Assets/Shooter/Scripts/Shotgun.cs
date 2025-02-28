using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    private int pellets;

    [SerializeField]
    private float spread;

    protected override void Shoot()
    {
        for(int i = 0; i < pellets; i++)
        {
            var bullet = Instantiate(
            bulletPrefab,
            bulletSpawnPoint.position,
            bulletSpawnPoint.rotation
            );

            Vector3 dir = bulletSpawnPoint.forward;
            dir += Random.insideUnitSphere * spread;

            bullet.AddForce(dir * bulletSpeed, ForceMode.Impulse);

            Destroy(bullet.gameObject, 3);
        }
    }
}
