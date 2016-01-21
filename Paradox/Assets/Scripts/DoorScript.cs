using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public PlayerController playerController;
    public float openAngle;
    public float smooth = 2f;
    public GameObject Door;

    void OnTriggerStay()
    {
        if (playerController.pickedItems>=5) { 
            OpenDoor();

            if ((int)Door.transform.localEulerAngles.y == openAngle)
            {
                Destroy(this);
            }
        }
    }

    public void OpenDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
        Door.transform.localRotation = Quaternion.Slerp(Door.transform.localRotation,
            targetRotation, smooth * Time.deltaTime);
    }

}
