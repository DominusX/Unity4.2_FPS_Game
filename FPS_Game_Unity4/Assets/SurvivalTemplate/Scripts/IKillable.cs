using UnityEngine;
using System.Collections;
using System;

public interface IKillable  
{
    void Kill();

    bool IsDead
    {
        get;
    }
	
}
