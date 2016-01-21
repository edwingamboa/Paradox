using UnityEngine;
using System.Collections;

public class TriggerCloset : MonoBehaviour {
    public GameObject DoorCloset;

    void OnTriggerStay() {
        OpenDoor();
        if ((int) DoorCloset.transform.localEulerAngles.y == 180) {
            Destroy(this);
        }
    }

    public void OpenDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
        DoorCloset.transform.localRotation = Quaternion.Slerp(DoorCloset.transform.localRotation,
            targetRotation, 10f * Time.deltaTime);
    }

}
