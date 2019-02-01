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


    //シーンメインボタン
    public void ChangeSceneMain()
    {
        SceneManager.LoadScene("Main");
    }

    //シーンランキングボタン
    public void ChangeSceneRanking()
    {
        SceneRankingManager.SetRank(1000);
        SceneManager.LoadScene("SceneRanking");
    }


}
