using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour
{
    public GameObject item;
    public float dropChance = 50;

	public void Drop()
    {
        var chance = Random.Range(1, 100);

        if(chance < dropChance)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }

    }
}
