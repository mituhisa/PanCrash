using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour {

    


	// Use this for initialization
	void Start () {

        //SceneResultManager.key = "aa";
        //SceneResultManager.keyconst=
        string a = SceneResultManager.KEY[1];
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Main");
        }

	}
}
