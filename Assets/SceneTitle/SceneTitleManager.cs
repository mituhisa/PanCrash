using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ChangeSceneMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChangeSceneRanking()
    {
        SceneManager.LoadScene("SceneRanking");
    }


}
