using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float speed;
    public bool move;
    private CardboardHead head;
    private Vector3 startingPosition;

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        startingPosition = transform.localPosition;
    }

    void Update()
    {
        if (Cardboard.SDK.Triggered)
        {
            move = !move;
        }
        if (move)
        {
            Debug.Log("Me voy a mover");
            Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized
                * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation * direction);
        }
    }
}
