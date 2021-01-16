using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // private variabls
    [SerializeField] private float speed;
    [SerializeField] private float horsePower = 0.0f;
    [SerializeField] private const float turnSpeed = 40.0f;
    [SerializeField] float rpm;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    // UI Dash Variables
    [SerializeField] TextMeshProUGUI speedomotorText;
    [SerializeField] TextMeshProUGUI rpmText;

    // wheels on ground check
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int WheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // we move the vehicle forword
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            // we turn the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            // Speed calculator
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); //mph for Km/H change 2.237 to 3.6
            speedomotorText.SetText("Speed: " + speed + "mph");

            // RPM calculaotr
            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    // Method to count wheels on ground
    bool IsOnGround()
    {
        WheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                WheelsOnGround++;
            }
        }
        if (WheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
