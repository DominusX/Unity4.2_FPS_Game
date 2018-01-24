using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(ItemDrop))]
[RequireComponent(typeof(AIFollow))]

public class EnemyKill : MonoBehaviour, IKillable
{
    public AudioClip deathSound;
    public AnimationClip deathAnimation;
    public bool IsDead { get; private set; }


    AIFollow aiFollow;
    ItemDrop itemDrop;

    void Start()
    {
        aiFollow = GetComponent<AIFollow>();
        itemDrop = GetComponent<ItemDrop>();
    }

    public void Kill()
    {
        IsDead = true;

        Destroy(gameObject, 1.5f);
        audio.PlayOneShot(deathSound);

        animation.CrossFade(deathAnimation.name);
        aiFollow.canMove = false;

        itemDrop.Drop();
    }

 
}
