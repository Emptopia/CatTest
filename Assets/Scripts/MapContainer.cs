using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapContainer : MonoBehaviour
{
    public static int[,] map1 =
    {
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 2, 2, 20, 2, 0, 0, 0, 0, 0, 19, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 0, 4, 4, 4, 4, 13, 4, 4, 4, 4, 4, 0, 2, 20, 2 },
        { 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2 },
        { 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2 },
        { 2, 2, 2, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 2, 2, 2 },
        { 2, 2, 2, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 2, 2, 2 }
    };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
