using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        this.CanBeMoved = true;
        this.entityType = EntityType.Box;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
