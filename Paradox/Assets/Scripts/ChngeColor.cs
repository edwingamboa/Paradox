using UnityEngine;
using System.Collections;

public class ChngeColor : MonoBehaviour {

    void Update()
    {
        if (Cardboard.SDK.Triggered)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
