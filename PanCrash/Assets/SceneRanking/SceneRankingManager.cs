using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class SceneRankingManager : MonoBehaviour
{

    InputField inputField;  //文字を入力するやつ

   private static int rank;     //順位
    Text NameText;              //名前一覧
    Text ScoreText;             //スコア一覧



    // Use this for initialization
    void Start()
    {
        //オブジェクトの取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();  //
        GameObject InputFieldObject=GameObject.Find("InputField");
        NameText = GameObject.Find("Name").GetComponent<Text>();
        ScoreText = GameObject.Find("Score").GetComponent<Text>();

        //名前入力するとこをオフに
        InputFieldObject. gameObject.SetActive(false);
        //rank = 1;

        if (rank <= 9)
        {
           InputFieldObject .gameObject.SetActive(true);    //順位が１０位以内だったら名前を入力するところを表示
           }


        ScoreText.text = null;
        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            //PlayerPrefs.SetInt(i.ToString(), 0);                  //名前とスコアをリセットするデバッグ用
            //PlayerPrefs.SetString(i.ToString() + "s", "******");//*****************************************************************************************************

            ScoreText.text += PlayerPrefs.GetInt(i.ToString(), 0).ToString() + "\n";    //スコアの取得
        }

        InputRanking();     //名前の取得

    }

    // Update is called once per frame
    void Update()
    {





    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SceneTitle");   //タイトルへシーンチェンジ
    }


    public void InputName()
    {
        if (inputField.text.Length <= 6)
        {
            PlayerPrefs.SetString(rank.ToString()+"s", inputField.text);        //入力した名前を保存
        }

        InputRanking();     //名前の取得

    }

    //
    private void InputRanking()
    {
        NameText.text = null;
        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            NameText.text += PlayerPrefs.GetString(i.ToString() + "s", "******") + "\n";
        }
        PlayerPrefs.Save();

    }


    //順位を格納する用関数    タイトルとリザルトで使用
    public static void SetRank(int _rank)
    {
        rank = _rank;       
    }


}