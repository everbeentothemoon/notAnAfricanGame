using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform emptySpace = null;
    private Camera camera;

    [SerializeField]
    private List<GameObject> gameObjectsList = new List<GameObject>();

    [SerializeField]
    private Transform[] correctPositions;

    [SerializeField]
    private TextMeshProUGUI outputText;

    [SerializeField]
    private GameObject myGameObject;

    void Update()
    {
        // Check if each object is in the correct position
        bool allCorrect = true;
        for (int i = 0; i < gameObjectsList.Count; i++)
        {
            if (gameObjectsList[i].transform.position != correctPositions[i].position)
            {
                allCorrect = false;
                break;
            }
        }

        // Output text if all objects are in the correct position
        if (allCorrect)
        {
            outputText.text = "Correct!";
            outputText.color = Color.green;
            myGameObject.gameObject.SetActive(false);
        }
        else
        {
            outputText.text = ""; // Clear the text if not all objects are in the correct position
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                //Debug.Log(hit.transform.name);
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 2)
                {
                    Vector2 lastEmptySpacePos = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePos;
                }
            }
        }
    }

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    
}
