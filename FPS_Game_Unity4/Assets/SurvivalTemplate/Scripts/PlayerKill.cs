using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour, IKillable
{
    public void Kill()
    {
        IsDead = true;
        Application.LoadLevel("GameOver");
    }

    public bool IsDead { get; private set; }
}
