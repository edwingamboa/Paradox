using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }
}
