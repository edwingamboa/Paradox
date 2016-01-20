using UnityEngine;
using System.Collections;

public class TriggerSoundController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
