using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Vector2 SSPoint;
    Vector2 startPos;
    float speed = 0;

    bool startFlg = false;

    Vector2 SecondPosition;
    Vector2 FirstPosition;
    [HideInInspector]
    public int MyNum = 0;

	// Use this for initialization
	void Start () {
        SSPoint = GameObject.Find("Sensor").transform.position;
        SecondPosition = GameObject.Find("SecondPoint").transform.position;
        FirstPosition = GameObject.Find("FirstPoint").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (startFlg)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;

                if (swipeLength > 1.0f)
                {
                    this.speed = swipeLength / 500.0f;
                }
            }

            transform.Translate(this.speed, 0, 0);

            if (transform.position.x > SSPoint.x)
            {
                //this.speed = 0;
                //transform.position = SSPoint;
            }
        }

        switch (MyNum)
        {
            case 0:
                if(transform.position.x > FirstPosition.x)
                {
                    transform.position = FirstPosition;
                    startFlg = true;
                    MyNum = 99;
                }
                else
                {
                    transform.Translate(0.1f, 0, 0);
                }
                break;
            case 1:
                if (transform.position.x > SecondPosition.x)
                {
                    transform.position = SecondPosition;
                    MyNum = 99;
                }
                else
                {
                    transform.Translate(0.1f, 0, 0);
                }
                break;
            case 2:
                break;
            default:
                break;
        }

        if (transform.position.x > 5) Destroy(gameObject);
	}
}
