using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int buttonIndex;

    // Flag to indicate whether the level is completed
    public bool isLevelCompleted;

    // Method to handle button click
    public void OnButtonClick()
    {
        // Update completion status when the button is clicked
        isLevelCompleted = true;

        // Deactivate the button on the main menu
        DeactivateMainMenuButton($"MainMenuButton{buttonIndex}");
    }

    // Method to deactivate the button on the main menu
    private void DeactivateMainMenuButton(string mainMenuButtonName)
    {
        // Find the main menu button based on the provided name
        GameObject mainMenuButton = GameObject.Find(mainMenuButtonName);

        // Deactivate the main menu button
        if (mainMenuButton != null)
        {
            mainMenuButton.SetActive(false);
        }
        else
        {
            Debug.LogError($"Main menu button {mainMenuButtonName} not found!");
        }
    }
}
