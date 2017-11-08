using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour
{
    public AnimationClip AttackAnimationClip;

	// Update is called once per frame
	void Update () 
    {// when we pressed left mouse button, animation blends from idle to attack animation
        //after attack has finished, it fades back to idle
        if (Input.GetMouseButton(0))
            animation.Play(AttackAnimationClip.name);
        else if (IsAttackFinished)
            animation.CrossFade(animation.clip.name);

    }

    private bool IsAttackFinished
    {// if animation timeline bigger than animation lenght it checks if atack is finished
        get
        {
            return animation[AttackAnimationClip.name].time > animation[AttackAnimationClip.name].length;
        }
    }
}
