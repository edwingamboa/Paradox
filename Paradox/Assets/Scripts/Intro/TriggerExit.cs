using UnityEngine;

public class TriggerExit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Application.Quit();
        //System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
