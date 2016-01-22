using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float interactDistance = 2f;
    public bool move;
    private CardboardHead head;
    public int pickedItems;
    public TextMesh countText;
    public float seconds = 0.0f;
    private new AudioSource audio;
    private float delay = 2f;

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        pickedItems = 0;
        updateCountText();
        audio = GetComponent<AudioSource>();
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
            if (Time.time >= seconds && !audio.isPlaying)
            {
                audio.volume = Random.Range(0.8f, 1);
                audio.pitch = Random.Range(0.8f, 1.1f);
                audio.Play();
                seconds += Time.deltaTime * 0.3f;
            }
        }

        Ray ray = new Ray(head.transform.position, head.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                delay -= Time.deltaTime;
                hit.collider.gameObject.GetComponent<Light>().intensity = 6f;
            }
            if (hit.collider.CompareTag("PickUp") && delay <= 0)
            {
                hit.collider.gameObject.SetActive(false);
                increasePickedUpItems();
                delay = 1f;
            }
        }

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
