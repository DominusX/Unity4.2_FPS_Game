using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour
{
    void Update()
    {
        if (Screen.lockCursor == false)
        {
            if (Input.GetMouseButtonDown(0))
                Screen.lockCursor = true;
        }
    }
    
}
