using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarumonoMove : MonoBehaviour {
    float Move;
    float MoveTimer;
	// Use this for initialization
	void Start () {
        Move = 0.01f;
        MoveTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,Move, 0);
        MoveTimer += Time.deltaTime;
        if( MoveTimer>= 0.5f)
        {
           Move = Move * (-1f);
            MoveTimer = 0;
        }
	}
}
