using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float x = 0.0f;
    float y = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(x, y, 0);
	}
}
