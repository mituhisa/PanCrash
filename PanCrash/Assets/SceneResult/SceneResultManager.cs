using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class SceneResultManager : MonoBehaviour
{

    private Text ScoreText;
    private int score;
    private static int rank=100;


    // Use this for initialization
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = Sensor.GetScore();
        ScoreText.text = "Score : "+score.ToString();


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeScene()
    {
        //Debug.Log("Change");

        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            if (score > PlayerPrefs.GetInt(i.ToString(), 0))
            {
                rank = i ;
                for (int j = CO.RANKING_LENGTH - 1; j > i; j--)
                {
                    PlayerPrefs.SetInt(j.ToString(), PlayerPrefs.GetInt((j - 1).ToString(), 0));
                }
                PlayerPrefs.SetInt(i.ToString(), score);
                PlayerPrefs.Save();
                break;
            }
        }

        SceneManager.LoadScene("SceneRanking");

    }

    public static int GetRank()
    {
        return rank;
    }


}