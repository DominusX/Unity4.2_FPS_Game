using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour, IPickupable
{
    public AnimationClip AttackAnimationClip;

    bool isMounted = false;

	void Update () 
    {// when we pressed left mouse button, animation blends from idle to attack animation
        //after attack has finished, it fades back to idle

        if (!isMounted)
            return;

        if (Input.GetMouseButton(0))
            animation.Play(AttackAnimationClip.name);
        else if (IsAttackFinished)
            animation.CrossFade(animation.clip.name);

    }

    public void Pickup(GameObject player)
    {
        isMounted = true;
        animation.Play();
    }

    private bool IsAttackFinished
    {// if animation timeline bigger than animation lenght it checks if atack is finished
        get
        {
            return animation[AttackAnimationClip.name].time > animation[AttackAnimationClip.name].length;
        }
    }
}
