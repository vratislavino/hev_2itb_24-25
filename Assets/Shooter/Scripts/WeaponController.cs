using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;
    List<Weapon> weapons = new List<Weapon>();

    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList();
        currentWeapon = weapons[0];
    }

    void Update()
    {
        if (currentWeapon.ShootInputMethod("Fire1"))
            currentWeapon.Attack();
    }
}
