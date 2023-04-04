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
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        activePlatform.GetComponent<Stand>().ChangeInput(activeObject);

                        _Circle.Move("changePosition",hit.collider.gameObject,_Stand.takeLastInput(),_Stand.position);
                        _Stand.emptyInput++;
                        _Stand.Circles.Add(activeObject);
                        activeObject = null;
                        activePlatform = null;
                    }
                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        activeObject = _Stand.takeLastCircle();
                        _Circle = activeObject.GetComponent<Circle>();
                        canMove = true;

                        if (_Circle.canMove)
                        {
                            _Circle.Move("pick",_Circle.mainStand,null,_Circle.mainStand.GetComponent<Stand>().position);
                            activePlatform = _Circle.mainStand;
                        }
                    }
                }
            }
        }
    }
}
