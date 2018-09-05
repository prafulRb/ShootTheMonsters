using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void FirstPlayBtn() {
        GetComponent<Animator>().SetTrigger("firstPlay");
        Debug.Log("Working");
    }
    public void GoToMainGame() {
        SceneManager.LoadScene("MainGame");
    }
    public void CreditsBtn() {
        GetComponent<Animator>().SetTrigger("credits");
    }
    public void CreditsBack() {
        GetComponent<Animator>().SetTrigger("back");
    }
}
