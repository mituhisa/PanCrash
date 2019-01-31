using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
    public GameObject PanGallPrefab;
    public GameObject KuikakeBreadPrefab;
    public int SpawnFlg;
    float RandomPanPosition;
    float SpawnTimer;
    int RandomNum;
	// Use this for initialization
	void Start () {
        SpawnFlg = 0;
        SpawnTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(SpawnFlg <=1)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer >= 1)
            {
                SpawnTimer = 0;
                RandomNum = Random.Range(0, 9);
                if (RandomNum >= 7)
                {

                    GameObject ClonePanGall = Instantiate(PanGallPrefab) as GameObject;
                    ClonePanGall.GetComponent<PanGallMove>().GeneratorFlg = this.gameObject;
                    ClonePanGall.transform.position = new Vector3(4.5f, -3.78f, -1);
                    SpawnFlg++;
                }
                else
                {
                    GameObject CloneKuikakePan = Instantiate(KuikakeBreadPrefab) as GameObject;
                    CloneKuikakePan.GetComponent<Breadmove>().GeneratorFlg = this.gameObject;
                    RandomPanPosition = Random.Range(-3.6f, 1f);
                    CloneKuikakePan.transform.position = new Vector3(4, RandomPanPosition, -1);
                    SpawnFlg++;
                }
            }
          
        
        }
	}
}
