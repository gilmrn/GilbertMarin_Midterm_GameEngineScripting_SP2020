using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    public float turningSpeed = 40.0f;

    public float horizontalInput;
    private float forwardInput;

    //values for jumping
    private Rigidbody playerRigidbody;
    public float jumpingForce = 10;
    public float gravityModifier;

    //prevents double jumping
    public bool onGround = true;

    //bool to detect game over
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //keeps player moving forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        horizontalInput = Input.GetAxis("Horizontal");

        //left and right input
        transform.Rotate(Vector3.up, turningSpeed * horizontalInput * Time.deltaTime);

        //jump input
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
            onGround = false;
        }


        //speed up input
        if (Input.GetKey("up"))
        {
            speed = 15.0f;
        }
        //slow down input
        else if (Input.GetKey("down"))
        {
            speed = 5.0f;
        }
        else
        {
            speed = 10.0f;
        }
       
    }

    //collision to detect player hitting obstacle and if they are on ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

}
