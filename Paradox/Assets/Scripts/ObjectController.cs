using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

    private CardboardHead head;
    private float delay = 0.0f;

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
    }

    void Update()
    {
        RaycastHit hit;
        bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
        // if looking at object for 2 seconds, enable/disable autowalk
        if (isLookedAt && Time.time > delay)
        {
            Debug.Log("ahora cambio de color");
            GetComponent<Renderer>().material.color = Color.blue;
            
        }
        // currently looking at object
        else if (isLookedAt)
        {
            Debug.Log("estas mirandome");
            GetComponent<Renderer>().material.color = Color.yellow;
            
        }
        // not looking at object
        else if (!isLookedAt)
        {
            Debug.Log("ahora no me miras");
            GetComponent<Renderer>().material.color = Color.red;
            delay = Time.time + 2.0f;
        }
    }
}
