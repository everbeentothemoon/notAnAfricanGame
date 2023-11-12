using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = {0,90,180,270};
    public float[] correctRotation;

    [SerializeField]
    bool isPlaced = false;

    int possibleRots = 1;

    NinkiManager manager;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<NinkiManager>();
    }

    private void Start()
    {
        possibleRots = correctRotation.Length;

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if(possibleRots == 1)
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                //Debug.Log("placed error" + gameObject.name);
                isPlaced = true;
                manager.correctMove();
            }
        }
        else if(possibleRots == 2)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                manager.correctMove();
                //Debug.Log("placed" + gameObject.name);
            }
        }


    }
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        //Debug.Log("clicked");

        if (possibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
            {
                isPlaced = true;
                manager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                manager.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
            {
                isPlaced = true;
                manager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                manager.wrongMove();
            }
        }
    }
}
