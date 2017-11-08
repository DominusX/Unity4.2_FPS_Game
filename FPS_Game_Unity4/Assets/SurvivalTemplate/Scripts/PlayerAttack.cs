using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Transform AttackPoint;
   
   

    void Attack()
    {
        //this crates a sphere cast at a point we determine and checks if it has intersected with any game objects
        var hits = Physics.OverlapSphere(AttackPoint.position, 0.5f); 

        foreach ( var hit in hits)
        {
            var hitables = hit.GetComponents(typeof(IHitable)); //??

            if (hitables == null)
                return;

            foreach (IHitable hitable in hitables) //??
            {
                hitable.Hit();
            }
        }
    }

    
}
