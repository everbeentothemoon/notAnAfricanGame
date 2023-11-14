using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rideThefuckenBoatNigga : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float rotationSpeed = 3f;

    private bool isRiding = false;
    private GameObject player;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Check if 'C' key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle the riding state
            isRiding = !isRiding;

            // If riding, set player position to boat position
            if (isRiding)
            {
                player.transform.position = this.gameObject.transform.position;
            }
        }

        // If riding, move the boat
        if (isRiding)
        {
            // Get input axes
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Move forward or backward
            MoveBoat(verticalInput);

            // Rotate left or right
            RotateBoat(horizontalInput);
        }
    }

    void MoveBoat(float input)
    {
        Vector3 forwardForce = transform.forward * input * forwardSpeed * Time.deltaTime;
        transform.position += forwardForce;
    }

    void RotateBoat(float input)
    {
        Vector3 rotation = new Vector3(0, input * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);
    }
}
