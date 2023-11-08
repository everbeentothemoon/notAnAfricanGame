using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimBitch : MonoBehaviour
{
    public float floatingGravity = 1.0f;
    public float sensitivity = 2.0f;
    private float maxYRotation = 20.0f;

    private float rotationX = 0;
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
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            playerRigidbody.transform.localRotation *= Quaternion.Euler(0, mouseX * sensitivity, 0);

            rotationX -= mouseY * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -20, maxYRotation);

            Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }
}
