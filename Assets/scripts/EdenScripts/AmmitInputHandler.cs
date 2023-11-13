using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            inputField.gameObject.SetActive(false);

            // Call the GameManager to mark the level as completed
            string currentLevelName = SceneManager.GetActiveScene().name;
            MainGameManager.instance.MarkLevelAsCompleted(currentLevelName);
        }
        else
        {
            resultTxt.text = "Incorrect";
            resultTxt.color = Color.red;
        }
    }
}

