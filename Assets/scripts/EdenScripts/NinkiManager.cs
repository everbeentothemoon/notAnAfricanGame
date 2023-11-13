using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NinkiManager : MonoBehaviour
{
    public GameObject pipesHolder;
    public GameObject[] pipes;

    [SerializeField]
    int totalPipes = 0;

    [SerializeField]
    int correctPipes = 0;

    [SerializeField]
    private TextMeshProUGUI outputText;

    void Start()
    {
        totalPipes = pipesHolder.transform.childCount;

        pipes = new GameObject[totalPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = pipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctPipes += 1;

        Debug.Log("correct move");

        Debug.Log("pipes correct" + correctPipes + "totalpipes" + totalPipes);
        if (correctPipes == totalPipes)
        {
            outputText.text = "Correct";
            outputText.color = Color.green;
            Debug.Log("win");
        }
    }

    public void wrongMove()
    {
        correctPipes -= 1;
    }
}