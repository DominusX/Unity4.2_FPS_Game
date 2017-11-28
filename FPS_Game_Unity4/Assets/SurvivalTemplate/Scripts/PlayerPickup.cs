using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {

    public Transform mountPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
