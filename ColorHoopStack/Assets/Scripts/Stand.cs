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
}
