using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
  
    public void LoadScene()
    {
        SceneManager.LoadScene("Map");
    }

    public void ToExit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
