using UnityEngine;
using System.Collections;
using System;

public class AmmoBar : MonoBehaviour
{
    public PlayerEquip playerEquip;
    public Stats playerStats;

    UISlider ammoBar;
    UILabel ammoLabel;
    public RangedAttack rangedAttack;
    bool isMounted = false;

    void Update ()
    {

        if (playerEquip.EquipPoint == true) // ?? equipped / unequipped ammo does not work
        {
            SetupReferences();
            rangedAttack.GetComponent<RangedAttack>().hasFired += PlayerHasFired;

            SetAmmoLabel();
            PlayerHasFired();
            return;
        }

        if (playerEquip.EquipPoint == false)
        {

        }


        //playerStats.GetComponent<Stats>().ammoCount -= PlayerHasFired;

    }
	

    private void SetupReferences()
    {
        ammoBar = GetComponent<UISlider>();
        ammoLabel = GetComponentInChildren<UILabel>();
    }

    private void SetAmmoLabel()
    {
        ammoLabel.text = playerStats.ammoCount.ToString();
    }

    void PlayerHasNotFired()
    {
        
    }

    void PlayerHasFired()
    {
        ammoBar.sliderValue = playerStats.ammoCount;

        SetAmmoLabel();

    }


}
