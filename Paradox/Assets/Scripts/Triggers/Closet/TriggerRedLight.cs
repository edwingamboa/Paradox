using UnityEngine;
using System.Collections;

public class TriggerRedLight : MonoBehaviour {

    public GameObject Light;    
    public bool flag;

    void OnTriggerEnter(Collider other)
    {
        Light.SetActive(flag);
    }
}
