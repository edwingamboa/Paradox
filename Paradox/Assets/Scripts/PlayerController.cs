using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public bool moving;
    CardboardHead head = null;

    public double thresholdAngle = 45;
    private const int RIGHT_ANGLE = 90; 

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
    }

    void Update()
    {
        if (Cardboard.SDK.Triggered)
        {
            this.MoveStop();
        }
        if(head.transform.eulerAngles.x >= thresholdAngle &&
            head.transform.eulerAngles.x <= RIGHT_ANGLE)
        {
            Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation * direction);
            moving = true;
        }

    }
    public void MoveStop()
    {
        if (!moving)
        {
            Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation * direction);
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
}
