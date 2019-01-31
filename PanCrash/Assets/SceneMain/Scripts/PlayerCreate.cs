using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour {

    int Max = 3;
    int player = 0;
    public GameObject Player;

    public GameObject[] playerBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player < Max)
        {
            GameObject p = Instantiate(Player, this.transform.position, this.transform.rotation);
            p.GetComponent<Player>().MyNum = player;
            playerBox[player] = p;
            player += 1;
        }

        if(playerBox[0] == null)
        {
            playerBox[0] = playerBox[1];
            playerBox[0].GetComponent<Player>().MyNum = 0;
            playerBox[1] = playerBox[2];
            playerBox[1].GetComponent<Player>().MyNum = 1;
            player = 2;
        }
	}
}
