using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;



    private Rigidbody rb;
    private int count;

      

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizantal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
     
        Vector3 movement = new Vector3 (moveHorizantal, 0.0f, moveVertical);


        rb.AddForce(movement * speed);

    }    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 13)
        {
            winText.text = "You Win";
        }
    }
}
