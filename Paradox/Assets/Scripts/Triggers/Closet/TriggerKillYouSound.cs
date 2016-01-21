using UnityEngine;
using System.Collections;

public class TriggerKillYouSound : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().Play();
    }
}
