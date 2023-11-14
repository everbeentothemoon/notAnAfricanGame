using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaarasSand : MonoBehaviour
{
    public bool interactedWithNpc = false;
    public float moveSpeed = 1.0f; // Adjust the speed as needed
    private Vector3 initialPosition;
    public bool isReturning;
    public GameObject player;
    public GameObject respawn;


    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (interactedWithNpc && !isReturning)
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        // Use local up direction
        transform.Translate(transform.up * -moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReturnToInitialPosition();
        }
    }

    void ReturnToInitialPosition()
    {
        isReturning = true;
        interactedWithNpc = false;
        transform.position = initialPosition;
        isReturning = false;
        player.transform.position = respawn.transform.position;
    }
}
