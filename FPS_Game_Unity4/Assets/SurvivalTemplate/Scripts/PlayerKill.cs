using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour, IKillable
{
    public void Kill()
    {
        print("Game Over");
    }
}
