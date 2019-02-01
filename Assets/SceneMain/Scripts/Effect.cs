using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
        if(gameObject.name == "Excellent")
        {
            if (transform.localScale.x > 1.0f)
            {
                transform.localScale = new Vector3(0, 0, 0);
                gameObject.SetActive(false);
            }
        }

        if (gameObject.name == "Great")
        {
            if (transform.localScale.x > 1.2f)
            {
                transform.localScale = new Vector3(0, 0, 0);
                gameObject.SetActive(false);
            }
        }

        if (gameObject.name == "Nice")
        {
            if (transform.localScale.x > 1.0f)
            {
                transform.localScale = new Vector3(0, 0, 0);
                gameObject.SetActive(false);
            }
        }
    }
}
