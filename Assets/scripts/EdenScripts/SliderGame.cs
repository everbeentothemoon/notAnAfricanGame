using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform emptySpace = null;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit)
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
}
