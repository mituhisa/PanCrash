using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class SceneResultManager : MonoBehaviour
{

    private Text ScoreText;     //スコアを表示するテキスト
    private int score;          //メインのスコアを格 納
    private static int rank;    //スコアに応じてランクを格納


    // Use this for initialization
    void Start()
    {
        //オブジェクトの取得
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();      
        //score = SceneMain.GetScore();****************************************************************************
        //score = 1000;
        ScoreText.text = "Score : "+score.ToString();

        rank = 1000;    //一旦ランク外の数字を入れる
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeScene()
    {
        //Debug.Log("Change");

        //ランキング
        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            //プレイヤーのスコアとランキングのスコアを上から比べて行って、プレイヤーのスコアが大きかったらランキングを並べ替える
            if (score > PlayerPrefs.GetInt(i.ToString(), 0))   
            {
                SceneRankingManager.SetRank(i);            //順位を格納

                for (int j = CO.RANKING_LENGTH - 1; j > i; j--)
                {
                    PlayerPrefs.SetInt(j.ToString(), PlayerPrefs.GetInt((j - 1).ToString(), 0));        //並べ替え
                }
                PlayerPrefs.SetInt(i.ToString(), score);
                PlayerPrefs.Save();
                break;
            }
        }

        SceneManager.LoadScene("SceneRanking");     //ランキングシーンへ

    }



}