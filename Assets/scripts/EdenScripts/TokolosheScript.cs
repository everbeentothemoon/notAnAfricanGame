using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokolosheScript : MonoBehaviour
{
    [SerializeField] InputField[] inputFields;
    [SerializeField] Text resultTxt;

    // Define a class to store the correct answers
    [Serializable]
    public class AnswerData
    {
        public InputField inputField;
        public string correctAnswer;
    }

    [SerializeField] AnswerData[] answers;

    public void ValidateFunction()
    {
        bool allCorrect = true;

        for (int i = 0; i < inputFields.Length; i++)
        {
            string input = inputFields[i].text;
            string correctAnswer = GetCorrectAnswer(inputFields[i]);

            if (input != correctAnswer)
            {
                allCorrect = false;
                break; // No need to continue checking if one is incorrect
            }
        }

        if (allCorrect)
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

    // Helper function to get correct answer for a specific input field
    string GetCorrectAnswer(InputField inputField)
    {
        foreach (AnswerData answerData in answers)
        {
            if (answerData.inputField == inputField)
            {
                return answerData.correctAnswer;
            }
        }
        return ""; // Default value if no answer is found (you can change this)
    }
}
