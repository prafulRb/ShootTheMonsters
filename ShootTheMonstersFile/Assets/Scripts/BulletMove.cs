using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMove : MonoBehaviour {
    float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        speed += 25 * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster") {
            Debug.Log("Bullet");
            other.gameObject.transform.parent.transform.parent.transform.parent.GetComponent<Animator>().SetTrigger("die");
            other.gameObject.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Rigidbody>().velocity = new Vector3(0, 12, 0);
            Destroy(other.gameObject.transform.parent.transform.parent.transform.parent.gameObject, 3);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.4f);
            other.gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("ScoreText").GetComponent<Text>().text = (int.Parse(GameObject.Find("ScoreText").GetComponent<Text>().text) +1).ToString();
            Destroy(this.gameObject);
            
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
