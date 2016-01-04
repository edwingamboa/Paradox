using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public PlayerController playerController;
    public float openAngle;
    public float closeAngle;
    public float smooth;
    public bool isLookedAt;
    private float delay = 0.0f;

	void Start () {
        openAngle = -90f;
        closeAngle = 0f;
        smooth = 2f;
        SetGazedAt(false);
	}

    public void SetGazedAt(bool gazedAt)
    {       
        isLookedAt = gazedAt;
    }
	
	// Update is called once per frame
	void Update () {      
        if (playerController.pickedItems >= 5)
        {
            OpenDoor();
        }        
	}  

    public void CloseDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, closeAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            targetRotation, smooth * Time.deltaTime);
    }

    public void OpenDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            targetRotation, smooth * Time.deltaTime);
    }
}
