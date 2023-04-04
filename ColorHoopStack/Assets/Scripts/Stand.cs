using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    [Header("------------Game Objects")]
    public GameObject position;
    public GameObject[] inputs;
    public List<GameObject> Circles = new List<GameObject>();


    [Header("------------Values")]
    public int emptyInput;
    int circleCompletedValue = 0;
    public GameObject takeLastCircle()
    {
        return Circles[^1];
    }
    public GameObject takeLastInput()
    {
        return inputs[emptyInput];
    }

    public void ChangeInput(GameObject deletedObject)
    {
        Circles.Remove(deletedObject);
        if (Circles.Count != 0)
        {
            emptyInput--;
            Circles[^1].GetComponent<Circle>().canMove = true;
        }
        else
        {
            emptyInput = 0;
        }
    }
    public void ControlCircle()
    {
        if (Circles.Count == 4)
        {
            string color = Circles[0].GetComponent<Circle>().color;
            foreach (var item in Circles)
            {
                if(color == item.GetComponent<Circle>().color)
                {
                    circleCompletedValue++;
                }
            }

            if(circleCompletedValue == 4)
            {
                _GameManager.StandCompleted();
                CompletedStand();
            }
            else
            {
                circleCompletedValue = 0;
            }
        }
    }
    void CompletedStand()
    {
        foreach (var item in Circles)
        {
            item.GetComponent<Circle>().canMove = false;
            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag = "completed";
        }
    }
}
