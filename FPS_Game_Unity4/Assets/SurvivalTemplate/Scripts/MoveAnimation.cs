using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour, IPickupable
{
    CharacterMotor Motor;

    public float  BaseAnimSpeed = 0.5f;
    public float  AnimSpeedModifier = 0.25f;

    Animation anim;
    bool isMounted = false;

    public void Pickup(GameObject player)
    {
        Motor = player.GetComponent<CharacterMotor>();
        isMounted = true;
    }

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isMounted)
            return;

        anim[anim.clip.name].speed = Motor.movement.velocity.magnitude * AnimSpeedModifier + BaseAnimSpeed;
	}
}
