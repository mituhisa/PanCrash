using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVJK : MonoBehaviour {

    public GameObject Pan;

    bool rotateStart = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!rotateStart)
        {
            if (transform.position.x > 2.2f)
            {
                transform.Translate(-0.2f, 0, 0);
            }
        }
        else
        {
            transform.Rotate(0, 0, 20);
            Vector2 AddPos = transform.position;
            AddPos += new Vector2(0.2f, 0.1f);
            transform.position = AddPos;

            if (transform.position.x > 6) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject pan = Instantiate(Pan, transform.position, transform.rotation);
        rotateStart = true;
    }
}
