using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        this.CanBeDestroyed = false;
        this.CanBeMoved = true;
        this.entityType = EntityType.Player;
        this.canExplode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
