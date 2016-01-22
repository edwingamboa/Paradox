using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerChangeScene : MonoBehaviour {

    public string Scene;

    void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(Scene);
        //SceneManager.LoadScene(Scene);
    }
}
