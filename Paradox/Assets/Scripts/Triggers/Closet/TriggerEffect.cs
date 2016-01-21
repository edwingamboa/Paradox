using UnityEngine;
using System.Collections;

public class TriggerEffect : MonoBehaviour {

    public GameObject Light;

    void OnTriggerEnter(Collider other)
    {
        Light.SetActive(true);
    }
}
