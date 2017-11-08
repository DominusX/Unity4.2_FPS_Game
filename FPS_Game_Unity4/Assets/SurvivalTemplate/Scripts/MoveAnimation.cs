using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour
{
    public CharacterMotor motor;

    public float  BaseAnimSpeed = 0.5f;
    public float  AnimSpeedModifier = 0.25f;

    Animation anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim[anim.clip.name].speed = motor.movement.velocity.magnitude * AnimSpeedModifier + BaseAnimSpeed;
	}
}
