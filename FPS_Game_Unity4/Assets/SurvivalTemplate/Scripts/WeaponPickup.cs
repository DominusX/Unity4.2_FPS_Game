using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour, IPickupable
{
    
    public void Pickup(GameObject player)
    {
        var playerEquip = player.GetComponent<PlayerEquip>();

        playerEquip.Equip(gameObject);

    }

    public void Drop(GameObject player)
    {
        
    }

}