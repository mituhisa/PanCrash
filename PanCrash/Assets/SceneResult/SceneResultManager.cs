using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneResultManager : MonoBehaviour
{

    private Text ScoreText;
    private int score;
    public static readonly string[] KEY = { "0", "1", "2", "3", "4" };
    int length;

    // Use this for initialization
    void Start()
    {

        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        //score = SceneMain.GetScore();

    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = score.ToString();
    }

  public  void ChangeScene()
    {
        Debug.Log("Change");

        for(int i = 0; i<length; i++)
        {
            if(score>  PlayerPrefs.GetInt(KEY[i], 0))
            {
                for(int j=length-1; j>i; j--)
                {
                    PlayerPrefs.SetInt(KEY[j], PlayerPrefs.GetInt(KEY[j - 1], 0));
                }
                PlayerPrefs.SetInt(KEY[i], score);
                break;
            }
        }

        //SceneManager.LoadScene("SceneRanking");

    }


}