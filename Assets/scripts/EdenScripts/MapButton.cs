using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MapButtonPressed()
    {
        SceneManager.LoadScene("Map");
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
