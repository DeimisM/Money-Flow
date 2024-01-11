using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform deal;
    public Transform deal1;
    public Transform deal2;
    public Transform deal3;
    public Transform deal4;
    public Transform deal5;

    public Transform donation;

    public Transform offer;
    public Transform offer1;

    public Transform credit;
    public Transform credit1;
    public Transform credit2;

    public Transform downsized;
    public Transform baby;

    public Transform money;
    public Transform money1;

    System.Random random = new System.Random();

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private void Roll()
    {
        int dice = random.Next(1, 7);
    }
}
