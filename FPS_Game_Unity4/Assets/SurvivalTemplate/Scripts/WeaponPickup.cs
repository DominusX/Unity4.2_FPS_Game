using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour, IPickupable
{
    public void Pickup(GameObject player)
    {
        var mountPoint = player.GetComponent<PlayerPickup>().mountPoint;

        transform.parent = mountPoint;
    }
}