using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerPlay : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
       // Application.LoadLevel("Garage");
        SceneManager.LoadScene("BedroomandBathroom");
    }
}
