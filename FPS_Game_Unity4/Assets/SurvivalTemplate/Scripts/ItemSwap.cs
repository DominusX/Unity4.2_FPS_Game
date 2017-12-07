using UnityEngine;
using System.Collections;

public class ItemSwap : MonoBehaviour {

    Transform stashPoint;
    Transform equipPoint;
    PlayerEquip playerEquip;

	// Use this for initialization
	void Start () {
        playerEquip = GetComponent<PlayerEquip>();
        equipPoint = playerEquip.EquipPoint;
        stashPoint = playerEquip.StashPoint;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Q))
        {
            var mountedItem = GetItem(equipPoint);
            var stashedItem = GetItem(stashPoint); 


            if (stashedItem != null)
                stashedItem.transform.parent = equipPoint;

            if (mountedItem != null)
            {
                playerEquip.UnEquip(mountedItem.gameObject);
            }

            if (stashedItem != null)
            {
                playerEquip.Equip(stashedItem.gameObject);
            }

        }
    }

    private Component GetItem(Transform point)
    {
        return point.GetComponentInChildren(typeof(IPickupable));
    }


}
