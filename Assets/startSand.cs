using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSand : MonoBehaviour
{
    private gaarasSand gaara;
    public GameObject gaaraa;

    void Start()
    {
        gaara = gaaraa.GetComponent<gaarasSand>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other);
            gaara.interactedWithNpc = true;
            gaara.isReturning = true;
            gaara.isReturning = false;
        }
    }
}
