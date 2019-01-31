using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Vector2 SSPoint;
    Vector2 startPos;
    Vector2 InitPos;
    float speed = 0;

    public Text text;

    [HideInInspector]
    public bool CheckFlg = false;
    [HideInInspector]
    public int Score = 0;

	// Use this for initialization
	void Start () {
        SSPoint = GameObject.Find("Sensor").transform.position;
        InitPos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        text.GetComponent<Text>().text = Score.ToString("0");
        if (!CheckFlg)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;

                if (Mathf.Abs(swipeLength) > 1.0f)
                {
                    this.speed = swipeLength / 500.0f; ;
                    CheckFlg = true;
                }
            }
        }

        transform.Translate(this.speed, 0, 0);

        if(transform.position.x > SSPoint.x)
        {
            this.speed = 0;
            transform.position = SSPoint;
        }

        if (!CheckFlg) this.gameObject.transform.position = InitPos;
	}
}
