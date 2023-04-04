using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject mainStand;
    public GameObject mainInput;
    public bool canMove;
    public string color;
    public GameManager _GameManager;

    GameObject position;
    GameObject _mainStand;

    bool picked, changePosition, join, turnBack;

    public void Move(string progress, GameObject Stand = null, GameObject Input = null, GameObject movetoObject = null)
    {
        switch (progress)
        {
            case "pick":
                position = movetoObject;
                picked = true;
                break;
            case "changePosition":
                _mainStand = Stand;
                mainInput = Input;
                position = movetoObject;
                changePosition = true;
                break;
            case "Input":

                break;
            case "turnBack":

                break;
            default:
                break;
        }
    }


    void Update()
    {
        if (picked)
        {
            transform.position = Vector3.Lerp(transform.position, position.transform.position, .02f);

            if (Vector3.Distance(transform.position, position.transform.position) < .10)
            {
                picked = false;
            }
        }
        if (changePosition)
        {
            transform.position = Vector3.Lerp(transform.position, position.transform.position, .02f);

            if (Vector3.Distance(transform.position, position.transform.position) < .10)
            {
                changePosition = false;
                join = true;
            }
        }
        if (join)
        {
            transform.position = Vector3.Lerp(transform.position, mainInput.transform.position, .02f);

            if (Vector3.Distance(transform.position, mainInput.transform.position) < .10)
            {
                transform.position = mainInput.transform.position;
                join = false;
                mainStand = _mainStand;

                if(mainStand.GetComponent<Stand>().Circles.Count > 1)
                {
                    mainStand.GetComponent<Stand>().Circles[^2].GetComponent<Circle>().canMove = false;
                }
                _GameManager.canMove = false;
            }
        }
    }
}
