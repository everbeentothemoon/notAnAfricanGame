using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimBitch : MonoBehaviour
{
    public float floatingGravity = 1.0f;
    public float sensitivity = 2.0f;
    private float maxYRotation = 20.0f;

    private Rigidbody playerRigidbody;
    private float originalGravity;

    private void Start()
    {
        playerRigidbody = null;
        originalGravity = Physics.gravity.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Physics.gravity = new Vector3(0, -floatingGravity, 0);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerRigidbody != null)
        {
            Physics.gravity = new Vector3(0, originalGravity, 0);
            playerRigidbody = null;
        }
    }

    private void Update()
    {
        if (playerRigidbody != null)
        {
            MovePlayer();
            RotateCamera();
        }
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 movement = playerRigidbody.transform.TransformDirection(moveDirection);
        playerRigidbody.velocity = new Vector3(movement.x, playerRigidbody.velocity.y, movement.z);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        playerRigidbody.transform.localRotation *= Quaternion.Euler(0, mouseX * sensitivity, 0);

        float rotationX = -mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYRotation, maxYRotation);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
