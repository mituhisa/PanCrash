using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-0.1f, 0.2f, 0,Space.World);
        transform.Rotate(0, 0, 20);
        transform.localScale += new Vector3(-0.03f, -0.03f, 0);

        if(transform.localScale.x < 0)
        {
            if(gameObject.name == "Excellent(Clone)")
            {
                GameObject.Find("Sensor").GetComponent<Sensor>().Score += 100;
                Destroy(gameObject);
            }
            if (gameObject.name == "Great(Clone)")
            {
                GameObject.Find("Sensor").GetComponent<Sensor>().Score += 50;
                Destroy(gameObject);
            }
            if (gameObject.name == "Nice(Clone)")
            {
                GameObject.Find("Sensor").GetComponent<Sensor>().Score += 10;
                Destroy(gameObject);
            }
        }
	}
}
