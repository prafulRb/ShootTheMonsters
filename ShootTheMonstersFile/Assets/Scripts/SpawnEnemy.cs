using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    float refTime;
    float spawnTime = 3;

    public GameObject MonsterObj;
    public Transform[] SpawnPoints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Time.time - refTime) > spawnTime) {
            int randomNum = Random.Range(0, SpawnPoints.Length);
            GameObject monsterNew = Instantiate(MonsterObj, SpawnPoints[randomNum].position, Quaternion.identity) as GameObject;
            if (randomNum == 2) {
                monsterNew.GetComponent<MonsterMovement>().dir = 1;
            }
            if (spawnTime > 0.8f) {
                spawnTime -= 0.1F;
            }
            refTime = Time.time;
        }
	}
}
