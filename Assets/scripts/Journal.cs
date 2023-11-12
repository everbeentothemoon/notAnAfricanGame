using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Map;

    // Start is called before the first frame update
    void Start()
    {
        Map.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }
    public void ToJournal()
    {
        Map.SetActive(false);
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }
    public void ToPage2()
    {
        Map.SetActive(false);
        Page1.SetActive(false);
        Page2.SetActive(true);
        Page3.SetActive(false);
    }
    public void ToPage3()
    {
        Map.SetActive(false);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(true);
    }
    public void FromPage3()
    {
        Map.SetActive(false);
        Page1.SetActive(false);
        Page2.SetActive(true);
        Page3.SetActive(false);
    }
    public void FromPage2()
    {
        Map.SetActive(false);
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
}
