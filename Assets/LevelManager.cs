using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public bool doneA;
    public bool doneJ;
    public bool doneN;
    public bool doneT;
    public bool doneM;

    [SerializeField] private Button Level1Button;
    [SerializeField] private Button Level2Button;
    [SerializeField] private Button Level3Button;
    [SerializeField] private Button Level4Button;
    [SerializeField] private Button Level5Button;

    private FlagHandler f;

    private int levelDoneFlag;

    public int LevelDoneFlag
    {
        get => levelDoneFlag;
        set => levelDoneFlag = value;
    }
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
            doneA = f.clearFlags[0];
            doneJ = f.clearFlags[1];
            doneN = f.clearFlags[2];
            doneT = f.clearFlags[3];
            doneM = f.clearFlags[4];

            SetButtonState(Level1Button, doneA);
            SetButtonState(Level2Button, doneJ);
            SetButtonState(Level3Button, doneN);
            SetButtonState(Level4Button, doneT);
            SetButtonState(Level5Button, doneM);
        }
    }

    private void SetButtonState(Button button, bool isLevelDone)
    {
        // Set the button active if the level is not done, otherwise, deactivate it.
        button.gameObject.SetActive(!isLevelDone);
    }


    public void ReturnToMenu()
    {
        if (GameObject.FindWithTag("FlagHandler").GetComponent<FlagHandler>())
        {
            FlagHandler f = GameObject.FindWithTag("FlagHandler").GetComponent<FlagHandler>();
            f.clearFlags[levelDoneFlag] = true;
        }
        SceneManager.LoadScene("Main Screen");
    }
}

