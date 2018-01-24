using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyKill))]
public class EnemyAttack : MonoBehaviour {

    public AnimationClip attackAnimation;
    public AudioClip attackAudio;
    public AudioClip chargingAudio;
    public float attackRange = 2;
    public float attackDelay = 2;

    EnemyKill enemyKill;
    Transform player;
    bool isCharging = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        enemyKill = GetComponent<EnemyKill>();
    }

    void Update ()
    {
        //check distance between enemy and player
        if (IsInAttackRange && !isCharging && !enemyKill.IsDead)
        {
            Invoke("Attack", attackDelay);
            audio.PlayOneShot(chargingAudio);
            isCharging = true;
        }
    }

    private bool IsInAttackRange
    {
        get { return Vector3.Distance(transform.position, player.position) < attackRange; }
    }

    private void Attack()
    {
        

        if (!IsInAttackRange && enemyKill.IsDead)
            return;

        ActivateHitables.HitAll(player.gameObject);

        animation.CrossFade(attackAnimation.name);

        audio.PlayOneShot(attackAudio);

        isCharging = false;

    }
}
