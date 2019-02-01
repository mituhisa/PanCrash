using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warumono : MonoBehaviour {

    float time = 0;

    public GameObject jk;

    bool crash = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 3.0f && time < 3.5f)
        {
            jk.SetActive(true);
        }

        if(time > 5.0f)
        {
            if (!crash)
            {
                transform.Translate(0.2f, 0, 0);
            }
        }

        if (crash)
        {
            if(transform.position.x > 0f)
            {
                transform.Translate(-0.01f, 0, 0);
            }
            else
            {
                transform.position = new Vector3(0f, -2.5f, 0);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        crash = true;
    }
}
