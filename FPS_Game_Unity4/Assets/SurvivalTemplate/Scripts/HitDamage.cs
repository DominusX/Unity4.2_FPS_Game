using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Stats))] //We did the same thing in HitSound script
//this Stats component will automaticaly be added in any gameobject with
public class HitDamage : MonoBehaviour, IHitable
{

    public Action hasDied;

    Stats stats;
    IKillable killable;

    bool isDead = false;

    void Start()
    {
        stats = GetComponent<Stats>();
        killable = (IKillable)GetComponent(typeof(IKillable));

        if (killable == null)
            throw new MissingComponentException("Requires an implementation of IKillable");
    }

    public void Hit()
    {
        stats.Health -= 10;

        if (stats.Health <= 0 && !isDead)
        {
            killable.Kill();
 
            if (hasDied != null)
                hasDied();

            isDead = true;
        }
    }

 }