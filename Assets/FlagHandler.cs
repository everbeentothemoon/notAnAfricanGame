using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    public bool[] clearFlags;

    // Method to update the completion status for a specific level
    public void SetLevelCompletion(int levelIndex, bool isCompleted)
    {
        if (levelIndex >= 0 && levelIndex < clearFlags.Length)
        {
            clearFlags[levelIndex] = isCompleted;
        }
        else
        {
            Debug.LogError("Invalid level index");
        }
    }
}
