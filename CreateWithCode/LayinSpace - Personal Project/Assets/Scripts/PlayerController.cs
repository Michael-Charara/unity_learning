using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playeRb;

    private float speed = 10.0f;
    private float zBound = 6.0f;


    // Start is called before the first frame update
    void Start()
    {
        playeRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainPlayerPosition();
    }

    // Moves player based on arrow key input

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playeRb.AddForce(Vector3.forward * speed * verticalInput);
        playeRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // Prevent from leaving the top or bottom of screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

    }
}
