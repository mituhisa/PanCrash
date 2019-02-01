using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Const;

public class test : MonoBehaviour {
    int score = 10;

    int[] array = { 15,12,8,5,3 };
	// Use this for initialization
	void Start () {
        //SceneResultManager.KEY = "TT";
        //SceneResultManager.key = "aa";
        //SceneResultManager.keyconst=
        //string a = SceneResultManager.KEY[1];

        

    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    //SceneManager.LoadScene("Main");
        //    Change();
        //    for(int i = 0; i < 5; i++)
        //    {
        //        Debug.Log(array[i]);
        //    }
        //}

	}



    public void Change()
    {
        Debug.Log("Change");

        for (int i = 0; i <CO. RANKING_LENGTH; i++)
        {
            if (score > array[i])
            {
                for (int j = CO.RANKING_LENGTH - 1; j > i; j--)
                {
                    array[j]= array[j - 1];
                }
               array[i]= score;
                
                break;
            }
        }

        //SceneManager.LoadScene("SceneRanking");

    }


}
