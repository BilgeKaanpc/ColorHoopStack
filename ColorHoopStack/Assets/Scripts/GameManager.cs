using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject activeObject;
    GameObject activePlatform;
    Circle _Circle;
    public bool canMove;

    public int targetStandCount;
    int completedStand;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit, 100))
            {
                if(hit.collider !=null && hit.collider.CompareTag("Stand"))
                {
                    if(activeObject != null && activePlatform != hit.collider.gameObject)
                    {

                    }
                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        activeObject = _Stand.takeLastCircle();
                        _Circle = activeObject.GetComponent<Circle>();
                        canMove = true;
                    }
                }
            }
        }
    }
}
