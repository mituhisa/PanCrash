using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJK : MonoBehaviour {

    float time = 0;
    float interval = 2;
    public GameObject JK;
    public GameObject OTK;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > interval)
        {
            int Dice = Random.Range(0, 10);
            if (Dice > 0)
            {
                GameObject jk = Instantiate(JK, this.transform.position, this.transform.rotation);
            }
            else
            {
                GameObject otk = Instantiate(OTK, this.transform.position, this.transform.rotation);
            }
            time = 0;
        }
	}
}
