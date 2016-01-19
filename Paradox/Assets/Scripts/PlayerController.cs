using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float interactDistance = 5f;
    public bool move;
    private CardboardHead head;
    public int pickedItems;
    public TextMesh countText;
    public float seconds = 0.0f;

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
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            if(Time.time >= seconds){
                GetComponent<AudioSource>().Play();
                seconds += Time.deltaTime * 0.3f;
            }
        }

        Ray ray 
    }

    public void increasePickedUpItems()
    {
        pickedItems++;
        updateCountText();
    }

    void updateCountText()
    {
        countText.text = "Items: " + pickedItems.ToString() + "/5";
    }
}
