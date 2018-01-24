using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {



    void OnTriggerEnter(Collider collider)
    {


        var pickupables = collider.GetComponents(typeof(IPickupable));

        if (pickupables == null)
            return;

        foreach(IPickupable pickup in pickupables)
        {
            pickup.Pickup(gameObject);
        }

    }

}
