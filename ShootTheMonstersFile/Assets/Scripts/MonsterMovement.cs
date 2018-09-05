using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour {
    public float speed = 8;
    public float dir = 1;
    bool canChangeDir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * dir*Time.deltaTime, 0, 0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanChangeDir") {
            canChangeDir = true;
        }
        if (other.gameObject.tag == "Boundary" && canChangeDir) {
            dir *= -1;
        }
    }
}
