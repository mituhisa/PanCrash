using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class SceneRankingManager : MonoBehaviour {

    Text[] RankingData=new Text[CO.RANKING_LENGTH];



	// Use this for initialization
	void Start () {

        for(int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            RankingData[i] = GameObject.Find("Score" + (i+1).ToString()).GetComponent<Text>();
            RankingData[i].text = ((i + 1).ToString()).PadLeft(2)+" : "  + (PlayerPrefs.GetInt(CO.KEY[i], 0)).ToString().PadLeft(4);
        }
		
	}
	
	// Update is called once per frame
	void Update () {




		
	}

    public void ChangeScene()
    {
        SceneManager.LoadScene("SceneTitle");
    }



}
