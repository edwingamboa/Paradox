using UnityEngine;
using System.Collections;

public class DoorCloset : MonoBehaviour {

    private float angle;
    private float smooth;
    public CardboardHead head;
    private float interactDistance = 3f;
    public GameObject Light;

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        angle = 180f;
        smooth = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(head.transform.position, head.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {

            if (hit.collider.CompareTag("Closet"))
            {
                OpenDoor();
                if ((int)transform.localEulerAngles.y == 180)
                {
                    Light.SetActive(true);
                }
            }
        }

    }

    public void OpenDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            targetRotation, smooth * Time.deltaTime);
    }

}
