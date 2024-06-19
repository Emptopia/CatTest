using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : Entity
{
    public bool passUp = false;
    public bool passDown = false;
    public bool passRight = false;
    public bool passLeft = false;

    public GameObject upTunnel;
    public GameObject downTunnel;
    public GameObject rightTunnel;
    public GameObject leftTunnel;
    
    // Start is called before the first frame update
    void Start()
    {
        this.entityType = EntityType.Tunnel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool tryIn(Dir dir)
    {
        switch (dir)
        {
            case(Dir.Up):
                if (passDown == false) return false;
                break;
            case(Dir.Down):
                if (passUp == false) return false;
                break;
            case(Dir.Right):
                if (passLeft == false) return false;
                break;
            case(Dir.Left):
                if (passRight == false) return false;
                break;
            default:
                break;
        }

        return true;

    }
    
    public bool tryOut(Dir dir)
    {
        switch (dir)
        {
            case(Dir.Up):
                if (passUp == false) return false;
                break;
            case(Dir.Down):
                if (passDown == false) return false;
                break;
            case(Dir.Right):
                if (passRight == false) return false;
                break;
            case(Dir.Left):
                if (passLeft == false) return false;
                break;
            default:
                break;
        }

        return true;

    }
    public void InitPassDir(bool up, bool down , bool right, bool left)
    {
        passUp = up;
        passDown = down;
        passRight = right;
        passLeft = left;

        if (passUp == false)
        {
            upTunnel.SetActive(false);
        }
        if (passDown == false)
        {
            downTunnel.SetActive(false);
        }
        if (passRight == false)
        {
            rightTunnel.SetActive(false);
        }
        if (passLeft == false)
        {
            leftTunnel.SetActive(false);
        }
    }
}
