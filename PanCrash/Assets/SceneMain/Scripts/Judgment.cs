using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgment : MonoBehaviour {

    float time = 0;

    public GameObject[] otherJudg;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        //for(int i=0; i < otherJudg.Length; i++)
        //{
        //    if (otherJudg[i].activeSelf) otherJudg[i].SetActive(false);
        //}

        if (time > 1.5f)
        {
            gameObject.SetActive(false);
            time = 0;
        }
	}
}
