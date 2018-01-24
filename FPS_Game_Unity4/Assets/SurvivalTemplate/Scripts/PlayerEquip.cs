using UnityEngine;
using System.Collections;

public class PlayerEquip : MonoBehaviour
{
    public Transform EquipPoint;
    public Transform StashPoint;

    public void Equip(GameObject item)
    {
        if (EquipPoint.childCount > 0)
            return;

        item.transform.parent = EquipPoint;


        foreach (IEquipable equipable in GetEquipables(item))
        {
            equipable.Equip(gameObject);
        }
    }

    public void UnEquip(GameObject item)
    {
        item.transform.parent = StashPoint;

        foreach (IEquipable equipable in GetEquipables(item))
        {
            equipable.UnEquip();
        }
    }

    private static Component[] GetEquipables(GameObject item)
    {
        return item.GetComponents(typeof(IEquipable));
    }
}
