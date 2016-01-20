using UnityEngine;
using System.Collections;

public class DoorCellar : MonoBehaviour
{

    public PlayerController playerController;
    public float openAngle;
    public float closeAngle;
    public float smooth;
    public bool isLookedAt;
    private float delay = 0.0f;
    public CardboardHead head;
    public float interactDistance = 3f;
    public GameObject PickUpCellar;
    public GameObject KeyCellar;
    private bool cellarOpened = false;

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        openAngle = -90f;
        closeAngle = 0f;
        smooth = 2f;
        SetGazedAt(false);
        PickUpCellar.GetComponent<Collider>().enabled = false;

    }

    public void SetGazedAt(bool gazedAt)
    {
        isLookedAt = gazedAt;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(head.transform.position, head.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("KeyCellar")){
                hit.collider.gameObject.SetActive(false);
            }

            if (hit.collider.CompareTag("Cellar") && !KeyCellar.activeSelf && !cellarOpened)
            {
                this.GetComponent<BoxCollider>().enabled = true;
                OpenDoor();
                if ((int)transform.localEulerAngles.x == 270 && (int)transform.localEulerAngles.y == 0 && (int)transform.localEulerAngles.z == 0)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    PickUpCellar.GetComponent<Collider>().enabled = true;
                }
            }
        }

        if (!PickUpCellar.activeSelf)
        {
            CloseDoor();
            cellarOpened = true;
        }
    }

    public void CloseDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(closeAngle, 270, 90);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            targetRotation, smooth * Time.deltaTime);
    }

    public void OpenDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(openAngle, 0, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            targetRotation, smooth * Time.deltaTime);
    }

}

