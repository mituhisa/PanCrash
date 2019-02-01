using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    float speed = -0.21f;
    float add = 0.001f;
    [HideInInspector]
    public bool speedup = false;

	// Use this for initialization
	void Start () {
        transform.position = new Vector2(7, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (speedup)
        {
            transform.Translate(speed, 0, 0);
            if (transform.position.x < 0)
            {
                speed *= 1.1f;
            }
            else
            {
                speed *= 0.98f;
            }

            if (transform.position.x < -6)
            {
                transform.position = new Vector2(7, 0);
                speed = -0.21f;
                speedup = false;
            }
        }
	}
}
