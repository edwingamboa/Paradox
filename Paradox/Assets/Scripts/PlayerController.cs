using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public bool move;
    private CardboardHead head;
    public int pickedItems;
    public Text countText; 

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        pickedItems = 0;
        updateCountText();
    }

    void Update()
    {
        if (Cardboard.SDK.Triggered)
        {
            move = !move;
        }
        if (move)
        {
            Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized
                * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation * direction);
        }
    }

    public void increasePickedUpItems()
    {
        pickedItems++;
        updateCountText();
    }

    void updateCountText()
    {
        countText.text = "Count: " + pickedItems.ToString();
    }
}
