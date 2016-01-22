using UnityEngine;
using System.Collections;

public class LightElectricalShockController : MonoBehaviour {

    public float minTime = 1f;
    public float maxTime = 5f;
    float timer;
    new Light light;

    void Start () {
        light = GetComponent<Light>();
        timer = Random.Range(minTime, maxTime);
	}
	
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            light.enabled = !light.enabled;
            GetComponent<AudioSource>().Play();
            timer = Random.Range(minTime, maxTime);
        }
	}
}
