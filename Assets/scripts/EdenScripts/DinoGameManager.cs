using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DinoGameManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    [SerializeField]
    private Sprite backImage;

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    // Update is called once per frame
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
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
        int loop = buttons.Count;
        int index = 0;

        for (int i=0; i < loop; i++)
        {
            if (index == loop / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
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
        Debug.Log("Button " + name);
    }
}
