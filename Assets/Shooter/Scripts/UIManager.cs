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

    [Space(20)]
    [Header("Crosshairs")]
    [SerializeField]
    private GameObject normalCrosshair;

    [SerializeField]
    private GameObject reloadCrosshair;

    [SerializeField]
    private Image reloadCrosshairFill;

    [SerializeField]
    private WeaponController weaponController;

    void Awake()
    {
        weaponController.WeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon oldW, Weapon newW)
    {
        if(oldW != null)
        {
            oldW.AmmoChanged -= OnAmmoChanged;
            oldW.ReloadProgressChanged -= OnReloadProgressChanged;
        }

        newW.AmmoChanged += OnAmmoChanged;
        newW.ReloadProgressChanged += OnReloadProgressChanged;

        OnReloadProgressChanged(0);
        weaponName.text = newW.name;
        //weaponImage.sprite = newW.weaponImage;
        ChangeAmmoText(newW);
    }

    private void ChangeAmmoText(Weapon w)
    {
        weaponAmmo.text = $"{w.CurrentAmmo}/{w.MaxAmmo}";
    }

    private void OnAmmoChanged()
    {
        ChangeAmmoText(weaponController.CurrentWeapon);
    }

    private void OnReloadProgressChanged(float progress)
    {
        if(progress == 1)
        {
            normalCrosshair.SetActive(false);
            reloadCrosshair.SetActive(true);
        } else if(progress > 0)
        {
            reloadCrosshairFill.fillAmount = progress;
        } else
        {
            normalCrosshair.SetActive(true);
            reloadCrosshair.SetActive(false);
        }

        // zmìnit crosshair
        // zpracovat progress
    }

}   // použít UI manager v praxi v Unity
    // vyøešit registraci dalších eventù (ammo)
