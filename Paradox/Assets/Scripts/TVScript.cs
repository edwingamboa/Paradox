using UnityEngine;
using System.Collections;

public class TVScript : MonoBehaviour {

    public Texture2D noiseTexture;
    public Texture2D scareTexture;
    public AudioClip noiseSound;
    public AudioClip scareSound;
    public float scareTime = 3f;

    bool showScare = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.mainTexture = scareTexture;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().clip = scareSound;
            GetComponent<AudioSource>().Play();
            showScare = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (showScare)
        {
            scareTime -= Time.deltaTime;
            if (scareTime <= 0)
            {
                GetComponent<Renderer>().material.mainTexture = noiseTexture;
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().clip = noiseSound;
                GetComponent<AudioSource>().Play();
                showScare = false;
            }
        }
	}
}
