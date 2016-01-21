using UnityEngine;
using System.Collections;

public class TriggerOpenDoor : MonoBehaviour {

    public GameObject Door;
    public PlayerController playerController;
    public GameObject TriggerSound;
    public GameObject TriggerGap;

    void OnTriggerEnter(Collider other)
    {
        if (playerController.pickedItems >= 5) {
            TriggerSound.SetActive(true);
            TriggerGap.SetActive(true);
            Door.GetComponent<AudioSource>().Play();
            Door.GetComponent<Animator>().enabled = true;
            Invoke("StopDoor",12f);
        }
    }

    void StopDoor() {
        Door.GetComponent<Animator>().Stop();
    }
}
