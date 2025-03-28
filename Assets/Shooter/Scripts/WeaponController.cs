using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<Weapon, Weapon> WeaponChanged;

    Weapon currentWeapon;
    public Weapon CurrentWeapon => currentWeapon;

    List<Weapon> weapons = new List<Weapon>();

    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon(weapons[0]);
    }

    void ChangeWeapon(Weapon newW)
    {
        if(currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);

        WeaponChanged?.Invoke(currentWeapon, newW);
        
        if (newW.IsReloading)
            newW.Reload();

        currentWeapon = newW;
        Debug.Log($"Setting weapon {currentWeapon.name}");
        currentWeapon.gameObject.SetActive(true);
    }

    void Update()
    {
        if (!currentWeapon)
            return;
        
        if (currentWeapon.ShootInputMethod("Fire1"))
            currentWeapon.Attack();

        if (Input.GetButtonDown("Reload"))
        {
            currentWeapon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapon(weapons[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(weapons[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapon(weapons[2]);
    }


}
