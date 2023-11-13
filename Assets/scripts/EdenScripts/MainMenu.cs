using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        // Disable buttons for completed levels
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Check if the corresponding level is completed
            if (MainGameManager.instance.IsLevelButtonActive(i))
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
