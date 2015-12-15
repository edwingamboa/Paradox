using UnityEngine;
using System.Collections;

public class ChngeColor : MonoBehaviour {

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
}
