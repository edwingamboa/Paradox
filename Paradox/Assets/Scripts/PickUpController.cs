using UnityEngine;
using System.Collections;

public class PickUpController : MonoBehaviour {

    public PlayerController playerController;
    private float delay = 0.0f;
    private bool isLookedAt;

    void Start()
    {
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        isLookedAt = gazedAt;

    }

    void Update()
    {       
        // if looking at object for 2 seconds, enable/disable autowalk
        if (isLookedAt && Time.time > delay)
        {
            gameObject.SetActive(false);
            playerController.increasePickedUpItems();
        }
        // currently looking at object
        else if (isLookedAt)
        {
            GetComponent<Renderer>().material.color = Color.green;

        }
        // not looking at object
        else if (!isLookedAt)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            delay = Time.time + 2.0f;
        }
    }
}
