using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public int minutes = 0;
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

        if (minutes > 0) {
            tm.text = Mathf.RoundToInt(minutes).ToString() + ":" + Mathf.RoundToInt(seconds).ToString();
        }
        else {
            tm.text = "GAME OVER";
        }
    }
}
