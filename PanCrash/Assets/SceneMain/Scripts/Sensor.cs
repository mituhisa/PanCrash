using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour {

    public Text text;

    bool PlayerFlg = false;
    bool SetFlg = false;

    int Status = 99;

    [HideInInspector]
    public int Score = 0;

    float waitTime = 0;
    float Judg = 0;

    Vector2 JKpos = Vector2.zero;

    GameObject player;
    GameObject JK;
    AudioSource aud;
    public GameObject[] Judgment;
    public GameObject[] Effects;
    public GameObject[] Pan;
    public AudioClip[] Se;

    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        text.GetComponent<Text>().text = Score.ToString("0");
		if(PlayerFlg && !SetFlg)      //プレイヤーが飛び出ていてJKが来てない場合
        {
            waitTime += Time.deltaTime;
            if (waitTime > 0.05f && !SetFlg)
            {
                //player.GetComponent<Player>().CheckFlg = false;
                //Destroy(player);
                PlayerFlg = false;
                waitTime = 0;
            }
        }
        else if(PlayerFlg && SetFlg)     //プレイヤーが飛び出ていてかつ、JKが来ている場合
        {
            waitTime = 0;
            Destroy(player);
            //JKとSensorとの距離を求めてそれに応じたスコアを加算する
            float y = Mathf.Abs(transform.position.y - JKpos.y);
            if (y > 0)
            {
                if(y >=0 && y < 0.1f) //Excelent
                {
                    Status = 0;
                    Judgment[Status].SetActive(true);
                    if(!Effects[Status].activeSelf) Effects[Status].SetActive(true);
                }
                else if(y >= 0.1f && y < 0.5f) //Great
                {
                    Status = 1;
                    Judgment[Status].SetActive(true);
                    if (!Effects[Status].activeSelf) Effects[Status].SetActive(true);
                }
                else if(y >= 0.5f && y < 0.8f) //Nice
                {
                    Status = 2;
                    Judgment[Status].SetActive(true);
                    if (!Effects[Status].activeSelf) Effects[Status].SetActive(true);
                }
                else if(y >= 0.8f && y < 1.0f) //Bad
                {
                    Status = 3;
                    Judgment[Status].SetActive(true);
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
                JK.GetComponent<JK>().rotStart = true;
                GameObject Clone1 = GameObject.Find("Excellent(Clone)");
                if (Clone1 == null) { GameObject Ex = Instantiate(Pan[Status], transform.position, transform.rotation); }

                if (!aud.isPlaying) aud.PlayOneShot(Se[Status]);
                Status = 99;
                break;
            case 1:
                JK.GetComponent<JK>().rotStart = true;
                GameObject Clone2 = GameObject.Find("Great(Clone)");
                if (Clone2 == null) { GameObject Gr = Instantiate(Pan[Status], transform.position, transform.rotation); }
                if (!aud.isPlaying) aud.PlayOneShot(Se[Status]);
                Status = 99;
                break;
            case 2:
                JK.GetComponent<JK>().rotStart = true;
                GameObject Clone3 = GameObject.Find("Nice(Clone)");
                if (Clone3 == null) { GameObject Ni = Instantiate(Pan[Status], transform.position, transform.rotation); }
                if (!aud.isPlaying) aud.PlayOneShot(Se[Status]);
                Status = 99;
                break;
            case 3:
                if (!aud.isPlaying) aud.PlayOneShot(Se[Status]);
                Status = 99;
                break;
            case 4:
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

        if(collision.tag == "OTK")
        {
            if(PlayerFlg)
            {
                aud.PlayOneShot(Se[4]);
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
