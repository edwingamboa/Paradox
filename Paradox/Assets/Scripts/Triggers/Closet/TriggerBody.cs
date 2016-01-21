using UnityEngine;
using System.Collections;

public class TriggerBody : MonoBehaviour {

    public GameObject Body;

    void OnTriggerEnter(Collider other)
    {
        Body.GetComponentInChildren<AudioSource>().Play();
        Body.GetComponent<Animator>().enabled = true;
        Invoke("StopBody", 0.25f);
    }

    void StopBody()
    {
        Body.GetComponent<Animator>().Stop();
       // Destroy(this);
    }
}
