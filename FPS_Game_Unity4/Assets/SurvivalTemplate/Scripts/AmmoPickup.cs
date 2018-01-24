using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class AmmoPickup : MonoBehaviour, IPickupable
{

    public int ammoAmount = 30;

    void Update()
    {
        Pickup();
    }

    public void Pickup(GameObject player)
    {
        var stats = player.GetComponent<Stats>();

        stats.ammoCount += ammoAmount;

        Destroy(gameObject);
    }

    public void Drop(GameObject player)
    {

    }


}
