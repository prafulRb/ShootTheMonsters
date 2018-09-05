using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Vector3 newPos;
    public float speed = 8;
	// Use this for initialization
	void Start () {
        newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.tag != "Gun")
                {
                    newPos = hit.point;
                    newPos = new Vector3(hit.point.x, hit.point.y, 0);
                }
                
            }
            
        }
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
        
    }
}
