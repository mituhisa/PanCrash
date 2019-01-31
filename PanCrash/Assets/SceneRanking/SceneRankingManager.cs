using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class SceneRankingManager : MonoBehaviour
{

    Text[] RankingData = new Text[CO.RANKING_LENGTH];

    InputField inputField;

    int rank;
    Text NameText;
    Text ScoreText;



    // Use this for initialization
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        rank = SceneResultManager.GetRank();
        //rank = 1;
        if (rank > 9)
        {
            GameObject.Find("InputField").gameObject.SetActive(false);
        }

        NameText = GameObject.Find("Name").GetComponent<Text>();
        ScoreText = GameObject.Find("Score").GetComponent<Text>();

        ScoreText.text = null;
        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            ScoreText.text += PlayerPrefs.GetInt(i.ToString(), 0).ToString() + "\n";
            //PlayerPrefs.SetString(i.ToString(), "******");//*****************************************************************************************************
        }

        InputRanking();

    }

    // Update is called once per frame
    void Update()
    {





    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SceneTitle");
    }


    public void InputName()
    {
        if (inputField.text.Length <= 6)
        {
            PlayerPrefs.SetString(rank.ToString(), inputField.text);
        }

        InputRanking();

    }
    private void InputRanking()
    {
        NameText.text = null;
        for (int i = 0; i < CO.RANKING_LENGTH; i++)
        {
            NameText.text += PlayerPrefs.GetString(i.ToString(), "******") + "\n";
        }
        PlayerPrefs.Save();

    }




}