using System;
using UnityEngine;

public class hejhej : MonoBehaviour
    
{
    //Variables and objects
    private int x = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x = 3;        
    }

    // Update is called once per frame
    void Update()
    {
        Console.WriteLine(x);
        Debug.Log(x);
        //Debug.Log(y);
    }
        
    
}
