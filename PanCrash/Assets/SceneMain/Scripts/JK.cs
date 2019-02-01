using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK : MonoBehaviour {

    [HideInInspector]
    public float speed = -0.1f;
    [HideInInspector]
    public bool rotStart = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject jkCreater = GameObject.Find("JKCreater");
        if (!jkCreater.GetComponent<CreateJK>().GameOver)
        {
            if (!rotStart)
            {
                Vector2 AddPos = transform.position;
                AddPos += new Vector2(0, speed);
                transform.position = AddPos;

                if (transform.position.y < -6.0f) Destroy(gameObject);
            }
            else
            {
                transform.Rotate(0, 0, 20);
                Vector2 AddPos = transform.position;
                AddPos += new Vector2(0.2f, 0.1f);
                transform.position = AddPos;

                if (transform.position.x > 6) Destroy(gameObject);
            }
        }
	}
}
