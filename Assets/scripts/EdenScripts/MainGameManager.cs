using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    private bool[] levelsCompleted;
    private bool[] levelButtonsActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize arrays
            levelsCompleted = new bool[5];
            levelButtonsActive = new bool[5];

            // Load saved progress
            LoadProgress();

            // Set all buttons as active by default
            for (int i = 0; i < levelButtonsActive.Length; i++)
            {
                levelButtonsActive[i] = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void MarkLevelAsCompleted(string levelName)
    {
        int levelIndex = GetLevelIndexByName(levelName);

        if (levelIndex != -1)
        {
            levelsCompleted[levelIndex] = true;
            levelButtonsActive[levelIndex] = false;
            SaveProgress();
        }
        else
        {
            Debug.LogError("Level name not found: " + levelName);
        }
    }

    public bool IsLevelButtonActive(int levelIndex)
    {
        return levelButtonsActive[levelIndex];
    }

    private void SaveProgress()
    {
        // Save the levelsCompleted and levelButtonsActive arrays to PlayerPrefs
        for (int i = 0; i < levelsCompleted.Length; i++)
        {
            PlayerPrefs.SetInt("LevelCompleted_" + i, levelsCompleted[i] ? 1 : 0);
            PlayerPrefs.SetInt("LevelButtonActive_" + i, levelButtonsActive[i] ? 1 : 0);
        }

        PlayerPrefs.Save();
    }

    private void LoadProgress()
    {
        // Load the levelsCompleted and levelButtonsActive arrays from PlayerPrefs
        for (int i = 0; i < levelsCompleted.Length; i++)
        {
            levelsCompleted[i] = PlayerPrefs.GetInt("LevelCompleted_" + i, 0) == 1;
            levelButtonsActive[i] = PlayerPrefs.GetInt("LevelButtonActive_" + i, 1) == 1;
        }
    }

    public int GetLevelIndexByName(string levelName)
    {
        // Replace this with your actual level names or identifiers
        string[] levelNames = { "Ammit", "Ninki", "Jengu", "Mokele", "Tokoloshe" };

        for (int i = 0; i < levelNames.Length; i++)
        {
            if (levelNames[i] == levelName)
            {
                return i;
            }
        }

        // If the level name is not found, return -1 or handle accordingly
        return -1;
    }
}

