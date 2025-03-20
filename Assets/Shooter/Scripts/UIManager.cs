using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField]
    private TMP_Text weaponName;

    [SerializeField]
    private TMP_Text weaponAmmo;

    [SerializeField]
    private Image weaponImage;

    [SerializeField]
    private WeaponController weaponController;

    void Start()
    {
        weaponController.WeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon oldW, Weapon newW)
    {
        weaponName.text = newW.name;
        //weaponImage.sprite = newW.weaponImage;
        weaponAmmo.text = $"{newW.CurrentAmmo}/{newW.MaxAmmo}";
    }
}   // použít UI manager v praxi v Unity
    // vyøešit registraci dalších eventù (ammo)
