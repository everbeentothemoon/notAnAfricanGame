using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rideTheWaves : MonoBehaviour
{
    public static rideTheWaves instance;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Debug.Log("Instance already exist, i shall destroy that nigga");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x/length + offset);
    }
}
