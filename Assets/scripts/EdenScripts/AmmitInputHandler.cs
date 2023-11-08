using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmitInputHandler : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultTxt;

    public void ValidateFunction()
    {
        string input = inputField.text;

        if (input == "devourer of the dead")
        {
            resultTxt.text = "Correct";
            resultTxt.color = Color.green;
        }
        else
        {
            resultTxt.text = "Incorrect";
            resultTxt.color = Color.red;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
