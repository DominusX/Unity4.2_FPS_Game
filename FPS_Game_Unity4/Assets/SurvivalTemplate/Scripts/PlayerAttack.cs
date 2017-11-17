using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask hitMask; //the reason is if we might want to ignore more than player object
   
   

    void Attack()
    {
        //this crates a sphere cast at a point we determine and checks if it has intersected with any game objects
        var hits = Physics.OverlapSphere(AttackPoint.position, 0.5f, hitMask); 

        foreach ( var hit in hits)
        {
            ActivateHitables.HitAll(hit.gameObject);
        }
    }

    
}
