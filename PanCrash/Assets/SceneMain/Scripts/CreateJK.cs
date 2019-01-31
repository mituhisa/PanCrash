using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJK : MonoBehaviour {

    float time = 0;
    float speed = -0.1f;
    float LvUpTime = 0;
    float interval = 2;
    public GameObject JK;
    public GameObject OTK;
    public GameObject SPUP;

    int max = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        LvUpTime += Time.deltaTime;
        if(time > interval)
        {
            int Dice = Random.Range(0, max);
            if (Dice > 0)
            {
                GameObject jk = Instantiate(JK, this.transform.position, this.transform.rotation);
                jk.GetComponent<JK>().speed = speed;
            }
            else
            {
                GameObject otk = Instantiate(OTK, this.transform.position, this.transform.rotation);
                otk.GetComponent<JK>().speed = speed;
            }
            time = 0;
        }

        if(LvUpTime > 5.0f)
        {
            if (interval > 0.5f)
            {
                interval = interval - 0.2f;
                speed = speed + -0.01f;
                LvUpTime = 0;
                SPUP.GetComponent<SpeedUp>().speedup = true;
            }
        }

        if(interval < 0.5f)
        {
            speed = Random.Range(-0.25f, -0.15f);
            max = Random.Range(2, 5);
        }
	}
}
