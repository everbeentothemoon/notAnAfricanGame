using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DinoGameManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    [SerializeField]
    private Sprite backImage;

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private string firstGuessPuzzle, secondGuessPuzzle;
    private int firstGuessIndex, secondGuessIndex;

    [SerializeField]
    private TextMeshProUGUI outputText;


    // Update is called once per frame
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        ShuffleList(gamePuzzles);

        gameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Button");
        
        for(int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = backImage;
        }
    }

    void AddGamePuzzles()
    {
       // int loop = buttons.Count;
        int index = 0;

        for (int i=0; i < buttons.Count; i++)
        {
            if (index == buttons.Count / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach(Button button in buttons)
        {
            button.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        // Check if the selected button is not already guessed
        int buttonIndex = int.Parse(name);
        if (buttons[buttonIndex].interactable == false)
        {
            // The button has already been guessed, do nothing
            return;
        }

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = buttonIndex;
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            buttons[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess && firstGuessIndex != buttonIndex)
        {
            secondGuess = true;
            secondGuessIndex = buttonIndex;
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            buttons[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;

            StartCoroutine(CheckIfMatch());
        }
    }

    IEnumerator CheckIfMatch()
    {
        yield return new WaitForSeconds(0.8f);

        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.5f);
            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;

            buttons[firstGuessIndex].image.color = new Color(0,0,0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0);

            CheckIfGameFinished();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            buttons[firstGuessIndex].image.sprite = backImage;
            buttons[secondGuessIndex].image.sprite = backImage;
        }
        yield return new WaitForSeconds(0.5f);
        firstGuess = secondGuess = false;
    }

    void CheckIfGameFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            outputText.text = "Correct";
            outputText.color = Color.green;
            //Debug.Log("Game Finished");
        }
    }

    void ShuffleList(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
