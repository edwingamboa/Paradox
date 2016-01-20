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
}
