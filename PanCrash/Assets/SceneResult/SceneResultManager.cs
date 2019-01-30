using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class SceneResultManager : MonoBehaviour
{
    //public static readonly string[] KEY = { "0", "1", "2", "3", "4" };
   //public static readonly int RANKING_LENGTH =5;

    private Text ScoreText;
    private int score;
    //public static readonly string[] KEY ;


    //public static 

    // Use this for initialization
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        //score = SceneMain.GetScore();


    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : "+score.ToString();
    }

    public void ChangeScene()
    {
        Debug.Log("Change");

        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            if (score > PlayerPrefs.GetInt(CO.KEY[i], 0))
            {
                for (int j = CO.RANKING_LENGTH - 1; j > i; j--)
                {
                    PlayerPrefs.SetInt(CO.KEY[j], PlayerPrefs.GetInt(CO.KEY[j - 1], 0));
                }
                PlayerPrefs.SetInt(CO.KEY[i], score);
                PlayerPrefs.Save();
                break;
            }
        }

        //SceneManager.LoadScene("SceneRanking");

    }


}