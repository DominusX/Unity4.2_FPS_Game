using UnityEngine;
using System.Collections;

public class EnemyKill : MonoBehaviour, IKillable
{
    public AudioClip deathSound;
    public AnimationClip deathAnimation;

    AIFollow aiFollow;

    void Start()
    {
        aiFollow = GetComponent<AIFollow>();

        if (aiFollow == null)
            throw new MissingComponentException("Missing AIFollow Component");
    }

    public void Kill()
    {
        Destroy(gameObject, 1.5f);
        audio.PlayOneShot(deathSound);

        animation.CrossFade(deathAnimation.name);
        aiFollow.canMove = false;


    }

 
}
