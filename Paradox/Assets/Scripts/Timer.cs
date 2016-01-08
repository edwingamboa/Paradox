using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public int minutes = 2;
    public float seconds = 0.0f;
    TextMesh tm;

    // Use this for initialization
    void Start () {
        tm = GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        seconds -= Time.deltaTime;
        if (seconds < 0) {
            seconds = 60.0f;
            minutes -= 1;
        }

        if (minutes >= 0) {
            if (seconds < 9.0f || seconds.Equals(9.0f))
            {
                tm.text = "0" + Mathf.RoundToInt(minutes).ToString() + ":0" + Mathf.RoundToInt(seconds).ToString();
            }
            else {
                tm.text = "0" + Mathf.RoundToInt(minutes).ToString() + ":" + Mathf.RoundToInt(seconds).ToString();
            }
        }
        else {
            this.GameOver();
        }
    }

    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
}
