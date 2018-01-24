using UnityEngine;
using System.Collections;
using System;

public class RangedAttack : MonoBehaviour, IEquipable
{
    public LayerMask hitMask;
    public float attackDistance = 500;

    public float AttackRate = 1.0f;

    public AudioClip attackSoundClip;

    bool isMounted = false;

    float lastAttackTime = 0;

    public Action hasFired;

    Stats playerStats;

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();

        if (playerStats == null)
            throw new MissingComponentException("Player GameObject needs to have Stats component");
    }

    void Update()
    {
        if (!isMounted)
            return;

        if (playerStats.ammoCount < 1)
            return;

        if (Time.time - lastAttackTime <= AttackRate)
            return;

        if (Input.GetMouseButton(0))
            Attack();
    }

    void Attack()
    {
        audio.PlayOneShot(attackSoundClip);

        lastAttackTime = Time.time;

        playerStats.ammoCount--;

        if (hasFired != null)
            hasFired();


        RaycastHit hit;
        var camera = Camera.main;


        var direction = camera.transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(camera.transform.position, direction, out hit, attackDistance, hitMask)==false)
            return;

        ActivateHitables.HitAll(hit.collider.gameObject);

        
    }

    public void Equip(GameObject player)
    {
        isMounted = true;
    }

    public void UnEquip()
    {
        isMounted = false;
    }
}
