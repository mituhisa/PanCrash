using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {
    public int[] Ranking_Num = new int[5];
    string[] Ranking_String = new string[5];
    public Text[] NumText = new Text[5];
    public Text[] StringText = new Text[5];
    string[] Key = new string[5] { "0", "1", "2", "3", "4"};
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5;)
        {
            Debug.Log("読み込み" + i);
            Ranking_Num[i] = PlayerPrefs.GetInt(Key[i]);
            Ranking_String[i] = PlayerPrefs.GetString(Key[i]);
            NumText[i].text = Ranking_Num[i].ToString();
            StringText[i].text = Ranking_String[i];
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
