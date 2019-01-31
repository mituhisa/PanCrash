using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanGallMove : MonoBehaviour {
    public GameObject GeneratorFlg;
    float Move;
    float MoveTimer;
    // Use this for initialization
    void Start () {
        Move = 0.01f;
        MoveTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(-0.1f, 0, 0);
        if (this.transform.position.x <= -4)
        {
            GeneratorFlg.GetComponent<Generator>().SpawnFlg--;
            Destroy(this.gameObject);
        }
        transform.Translate(0, Move, 0);
        MoveTimer += Time.deltaTime;
        if (MoveTimer >= 0.5f)
        {
            Move = Move * (-1f);
            MoveTimer = 0;
        }
    }
}
