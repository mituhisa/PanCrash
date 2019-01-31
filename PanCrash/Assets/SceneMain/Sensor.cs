using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {

    bool PlayerFlg = false;
    bool SetFlg = false;

    int Status = 99;

    float waitTime = 0;
    float Judg = 0;

    Vector2 JKpos = Vector2.zero;

    GameObject player;
    GameObject JK;
    public GameObject[] Judgment;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerFlg && !SetFlg)      //プレイヤーが飛び出ていてJKが来てない場合
        {
            waitTime += Time.deltaTime;
            if (waitTime > 0.05f && !SetFlg)
            {
                player.GetComponent<Player>().CheckFlg = false;
                PlayerFlg = false;
                waitTime = 0;
            }
        }
        else if(PlayerFlg && SetFlg)     //プレイヤーが飛び出ていてかつ、JKが来ている場合
        {
            waitTime = 0;
            //JKとSensorとの距離を求めてそれに応じたスコアを加算する
            float y = (transform.position.y - JKpos.y)*-1;
            Debug.Log(y);
            Debug.Log(JKpos);
            if (y > 0)
            {
                if(y >=0 && y < 0.1f) //Excelent
                {
                    Status = 0;
                    Judgment[Status].SetActive(true);
                    for(int i=0; i<Judgment.Length; i++)
                    {
                        if(i != Status) Judgment[i].SetActive(false);
                    }
                }
                else if(y >= 0.1f && y < 0.5f) //Great
                {
                    Status = 1;
                    Judgment[Status].SetActive(true);
                    for (int i = 0; i < Judgment.Length; i++)
                    {
                        if (i != Status) Judgment[i].SetActive(false);
                    }
                }
                else if(y >= 0.5f && y < 0.8f) //Nice
                {
                    Status = 2;
                    Judgment[Status].SetActive(true);
                    for (int i = 0; i < Judgment.Length; i++)
                    {
                        if (i != Status) Judgment[i].SetActive(false);
                    }
                }
                else if(y >= 0.8f && y < 1.0f) //Bad
                {
                    Status = 3;
                    Judgment[Status].SetActive(true);
                    for (int i = 0; i < Judgment.Length; i++)
                    {
                        if (i != Status) Judgment[i].SetActive(false);
                    }
                }
                else //Miss
                {
                    Status = 4;
                }
            }
            
        }else if(!PlayerFlg && JKpos != Vector2.zero)   //プレイヤーが出ていなくて、JKが通り過ぎた場合
        {
            Status = 4;
        }

        switch (Status)
        {
            case 0:
                Debug.Log("Excelent");
                JK.GetComponent<JK>().rotStart = true;
                //JKpos = Vector2.zero;
                player.GetComponent<Player>().Score += 100;
                Status = 99;
                break;
            case 1:
                Debug.Log("Greate");
                JK.GetComponent<JK>().rotStart = true;
                //JKpos = Vector2.zero;
                player.GetComponent<Player>().Score += 50;
                Status = 99;
                break;
            case 2:
                Debug.Log("Nice");
                JK.GetComponent<JK>().rotStart = true;
                //JKpos = Vector2.zero;
                player.GetComponent<Player>().Score += 10;
                Status = 99;
                break;
            case 3:
                Debug.Log("Bad");
                //Destroy(JK);
                //JKpos = Vector2.zero;
                player.GetComponent<Player>().Score += 5;
                Status = 99;
                break;
            case 4:
                Debug.Log("Miss");
                //Destroy(JK);
                //JKpos = Vector2.zero;
                Status = 99;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;
            PlayerFlg = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "JK")
        {
            if (PlayerFlg)
            {
                if (!SetFlg)
                {
                    SetFlg = true;
                    JKpos = collision.gameObject.transform.position;
                    JK = collision.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //通過したという事だからミス
        JKpos = Vector2.zero;
        Status = 4;
        SetFlg = false;
    }
}
