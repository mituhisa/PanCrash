using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadmove : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject GeneratorFlg;
	// Use this for initialization
	void Start () {
        
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-2.5f, 3.5f),ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0,9);
        if (this.transform.position.x <= -4)
        {
            GeneratorFlg.GetComponent<Generator>().SpawnFlg--;
            Destroy(this.gameObject);
        }
	}
}
