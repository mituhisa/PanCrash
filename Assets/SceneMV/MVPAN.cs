using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVPAN : MonoBehaviour {

    float FallSpeed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-0.01f, FallSpeed, 0, Space.World);
        transform.Rotate(0, 0, 20);
        //transform.localScale += new Vector3(-0.03f, -0.03f, 0);

        FallSpeed -= Time.deltaTime*0.2f;
    }
}
