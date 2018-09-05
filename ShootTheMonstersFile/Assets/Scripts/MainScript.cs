using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {
    public float speed = 20;
    int dir = 1;
    public Transform target;
    Vector3 newPos;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    bool canShoot = true;

    public Slider healthSlider;
    public Image redBloodImg;

    AudioSource shootAudio;
    public AudioClip finalSound;
    public AudioClip firstClip;
    bool died = false;
    public GameObject GameOverPanel;
    public Text CurrentText;
    public Text HighScoreText;
    public GameObject muzzleObj;
	// Use this for initialization
	void Start () {
        newPos = target.position;
        shootAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        if (Input.GetMouseButtonDown(0) && canShoot)
        {

            StartCoroutine(ShootBullet());
            StartCoroutine(ReloadBullet());
            canShoot = false;
        }
        
        
	}
    IEnumerator ShootBullet() {
        yield return new WaitForSeconds(0.1f);
        shootAudio.pitch = Random.Range(0.8f, 1.4f);
        shootAudio.Play();
        GameObject bulletNew = Instantiate(bullet, bulletSpawnPoint.position, bullet.transform.rotation) as GameObject;
        bulletNew.SetActive(true);
        GameObject.Find("monster gun").GetComponent<Animator>().SetTrigger("shoot");
        muzzleObj.GetComponent<Animator>().SetTrigger("muzzle");
    }

    IEnumerator ReloadBullet() {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster") {
            healthSlider.value -= 0.1f;
            transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            if (healthSlider.value > 0.5)
            {
                redBloodImg.GetComponent<Animator>().SetTrigger("hit");
            }
            else {
                redBloodImg.GetComponent<Animator>().SetTrigger("loop");
                if (Camera.main.GetComponent<AudioSource>().clip != finalSound) {
                    Camera.main.GetComponent<AudioSource>().clip = finalSound;
                    Camera.main.GetComponent<AudioSource>().Play();
                }

            }
            if (healthSlider.value == 0 && !died) {
                //SetHighScore
                int prevScore = PlayerPrefs.GetInt("HighScore");
                int currentScore = int.Parse(GameObject.Find("ScoreText").GetComponent<Text>().text);
                if (currentScore > prevScore) {
                    PlayerPrefs.SetInt("HighScore", currentScore);
                }
                PlayerPrefs.SetInt("CurrentScore", currentScore);
                GameOverPanel.SetActive(true);
                CurrentText.text = "Kills  "+currentScore.ToString();
                HighScoreText.text = "Highest  " + (PlayerPrefs.GetInt("HighScore")).ToString();
                died = true;
                GameObject.Find("ScoreText").SetActive(false);
                Camera.main.GetComponent<AudioSource>().clip = firstClip;
                Camera.main.GetComponent<AudioSource>().Play();
                Time.timeScale = 0;
            }
        }
    }
    public void ReloadLevel() {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void GoToHome() {
        Time.timeScale = 1;
        SceneManager.LoadScene("FirstMainMenu");
    }
}
