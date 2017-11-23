using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    //reference to the player health
    public Stats playerStats; 
    UISlider healthBar;
    UILabel healthLabel;

	void Start ()
    {
        SetupReferences();
        playerStats.GetComponent<HitDamage>().hasTakenDamage += PlayerHasTakenDamage;

        SetupExceptions();
        SetHealthLabel();
    }

    private void SetupReferences()
    {
        healthBar = GetComponent<UISlider>();
        healthLabel = GetComponentInChildren<UILabel>();
    }

    private void SetupExceptions()
    {
        if (playerStats == null)
            throw new MissingReferenceException("Cannot find player stats or player");

        if(healthBar == null)
            throw new MissingComponentException("HealthBar requires UISlider");

        if (healthLabel == null)
            throw new MissingReferenceException("HealthBar requires a UILabel child. Unable to find");
    }

    private void SetHealthLabel()
    {
        healthLabel.text = playerStats.Health.ToString();
    }

    void PlayerHasTakenDamage ()
    {
        healthBar.sliderValue = playerStats.Health / 500;

        SetHealthLabel();
    }
}
