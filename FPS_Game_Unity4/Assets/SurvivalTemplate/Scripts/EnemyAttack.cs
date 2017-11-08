﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public AnimationClip attackAnimation;
    public AudioClip attackAudio;
    public AudioClip chargingAudio;
    public float attackRange = 2;
    public float attackDelay = 2;

    Transform player;
    bool isCharging = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update ()
    {
        //check distance between enemy and player
        if (Vector3.Distance(transform.position, player.position) < attackRange && !isCharging)
        {
            Invoke("Attack", attackDelay);
            audio.PlayOneShot(chargingAudio);
            isCharging = true;
        }
    }

    private void Attack()
    {
        ActivateHitables.HitAll(player.gameObject);

        animation.CrossFade(attackAnimation.name);

        audio.PlayOneShot(attackAudio);
        isCharging = false;
    }
}
