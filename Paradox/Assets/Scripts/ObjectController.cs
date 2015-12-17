using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

    void Start()
    {
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }
}
