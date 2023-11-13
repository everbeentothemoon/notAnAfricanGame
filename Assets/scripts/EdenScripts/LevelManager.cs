using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Reference to your FlagHandler script
    public FlagHandler f;

    private void Awake()
    {
        if (!f)
        {
            f = GameObject.FindWithTag("FlagHandler").GetComponent<FlagHandler>();
            DontDestroyOnLoad(f.gameObject);
        }
    }

    private void Start()
    {
        if (this.gameObject.CompareTag("GameController"))
        {
            // Assuming your buttons are named "MainMenuButton0", "MainMenuButton1", etc.
            for (int i = 0; i < f.clearFlags.Length; i++)
            {
                SetButtonState(i);
            }
        }
    }

    private void SetButtonState(int index)
    {
        GameObject mainMenuButton = GameObject.Find($"MainMenuButton{index}");
        if (mainMenuButton != null)
        {
            // Set the button active if the level is not done, otherwise, deactivate it.
            mainMenuButton.SetActive(!f.clearFlags[index]);

            // Set the button index
            mainMenuButton.GetComponent<LevelButton>().buttonIndex = index;
        }
        else
        {
            Debug.LogError($"Main menu button {index} not found!");
        }
    }
}
