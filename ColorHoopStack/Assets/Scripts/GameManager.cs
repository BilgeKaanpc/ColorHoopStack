using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject activeObject;
    GameObject activePlatform;
    Circle _Circle;
    public bool canMove;

    public int targetColorCount;
    int completedColor;

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

                        if(_Stand.Circles.Count != 4 && _Stand.Circles.Count != 0)
                        {
                            if (_Circle.color == _Stand.Circles[^1].GetComponent<Circle>().color)
                            {
                                activePlatform.GetComponent<Stand>().ChangeInput(activeObject);

                                _Circle.Move("changePosition", hit.collider.gameObject, _Stand.takeLastInput(), _Stand.position);
                                _Stand.emptyInput++;
                                _Stand.Circles.Add(activeObject);
                                _Stand.ControlCircle();
                                activeObject = null;
                                activePlatform = null;
                            }
                            else
                            {
                                _Circle.Move("Input");
                                activeObject = null;
                                activePlatform = null;
                            }


                        }
                        else if(_Stand.Circles.Count == 0)
                        {
                            activePlatform.GetComponent<Stand>().ChangeInput(activeObject);

                            _Circle.Move("changePosition", hit.collider.gameObject, _Stand.takeLastInput(), _Stand.position);
                            _Stand.emptyInput++;
                            _Stand.Circles.Add(activeObject);
                            _Stand.ControlCircle();
                            activeObject = null;
                            activePlatform = null;
                        }
                        else
                        {
                            _Circle.Move("Input");
                            activeObject = null;
                            activePlatform = null;
                        }
                    }
                    else if (activePlatform == hit.collider.gameObject)
                    {
                        _Circle.Move("Input");
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

    public void StandCompleted()
    {
        completedColor++;
        if(completedColor == targetColorCount)
        {

        }
    }
}
