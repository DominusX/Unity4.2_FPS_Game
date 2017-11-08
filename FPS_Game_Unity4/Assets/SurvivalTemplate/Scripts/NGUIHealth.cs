using UnityEngine;
using System.Collections;

public class NGUIHealth : MonoBehaviour
{
    public UILabel label;

    float health = 100.0f;

    void OnClick()
    {
        health -= 10;
        label.text = health.ToString();
    }
}
	

