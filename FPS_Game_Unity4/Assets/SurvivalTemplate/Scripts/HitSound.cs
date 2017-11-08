using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
//we added a audioSource Component to HitSound Script to make it assigned to the script
//so when we add the HitSound Script to any gameobject, 
//it also automaticly adds AudioSource component.
public class HitSound : MonoBehaviour, IHitable
{
    public AudioClip clip;

    public void Hit()
    {
        audio.PlayOneShot(clip);
    }
}
