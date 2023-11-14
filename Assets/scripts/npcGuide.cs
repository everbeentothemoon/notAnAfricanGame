using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcGuide : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform player; 
    public Vector3 fixedUpDirection = Vector3.up; 
    public float activationDistance = 5f;

    private bool hasPlayed = false; 

    private void Start()
    {
        button.onClick.AddListener(PlayAudio);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= activationDistance && !hasPlayed)
        {
            PlayAudio();
            hasPlayed = true;
        }

        Vector3 directionToPlayer = player.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, fixedUpDirection);

        transform.rotation = targetRotation;
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
