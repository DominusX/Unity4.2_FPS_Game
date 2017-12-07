using UnityEngine;
using System.Collections;

public interface IEquipable {

    void Equip(GameObject player);
    void UnEquip();
}
