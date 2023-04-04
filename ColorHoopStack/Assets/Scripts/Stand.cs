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
}
