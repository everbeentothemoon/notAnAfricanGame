using System.Collections;
using UnityEngine;

public class swimBitch : MonoBehaviour
{
    public float floatingGravity = 1.0f;
    public float sensitivity = 2.0f;
    private float maxYRotation = 20.0f;

    public float drowningTime = 15.0f;
    private float currentDrowningTime;

    private Rigidbody playerRigidbody;
    private float originalGravity;
    private bool isDrowning;

    public Transform respawnPoint;

    private void Start()
    {
        playerRigidbody = null;
        originalGravity = Physics.gravity.y;
        currentDrowningTime = drowningTime;
        isDrowning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Physics.gravity = new Vector3(0, -floatingGravity, 0);
                StartDrowningTimer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Outta the water");
        if (other.CompareTag("Player") && playerRigidbody != null)
        {
            Physics.gravity = new Vector3(0, originalGravity, 0);
            playerRigidbody = null;
            StopDrowningTimer();
        }
    }

    private void Update()
    {
        if (playerRigidbody != null)
        {
            MovePlayer();
            RotateCamera();
        }

        if (isDrowning)
        {
            UpdateDrowningTimer();
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

    private void StartDrowningTimer()
    {
        isDrowning = true;
        currentDrowningTime = drowningTime;
        StartCoroutine(DrowningTimer());
    }

    private void StopDrowningTimer()
    {
        isDrowning = false;
        StopAllCoroutines();
    }

    private void UpdateDrowningTimer()
    {
        currentDrowningTime -= Time.deltaTime;

        if (currentDrowningTime <= 0)
        {
            TeleportToRespawn();
        }
    }

    private void TeleportToRespawn()
    {
        if (respawnPoint != null)
        {
            playerRigidbody.transform.position = respawnPoint.position;
            playerRigidbody.velocity = Vector3.zero;
            currentDrowningTime = drowningTime;
        }
    }

    IEnumerator DrowningTimer()
    {
        while (isDrowning)
        {
            yield return null;
        }
    }
}
