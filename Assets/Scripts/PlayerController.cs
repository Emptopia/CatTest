using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    public bool isMove = false;
    public float moveTime = 0.05f;
    public float timeSet = 0f;
    
    
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            timeSet += Time.deltaTime;
        }
        if (timeSet >= moveTime)
        {
            isMove = false;
            timeSet = 0;
        }

        if (isMove == false)
        {
            if (player.isInTunnel)
            {
                isMove = true;
                Entity.Dir d = player.selfDir;
                
                //自动移动
                if (!player.Move(player.selfDir))
                {
                    if (!player.Move(player.myLeft()))
                    {
                        if (!player.Move(player.myRight()))
                        {
                            //返回原点，待补充
                        }
                    }
                }
                
            }
            else
            {
                //逃离隧道可以判断引爆
                if (player.readyForExplode == true)
                { 
                    int tposX;
                    int tposY;
                    Entity.Dir d = player.selfDir;
                    //遍历，存在1个无实体则不引爆
                    player.dirToPos(d,out tposX,out tposY);
                    Ground g1 = GameManager.Instance.GetGround(tposX, tposY);
                    d = player.myLeft();
                    player.dirToPos(d,out tposX,out tposY);
                    Ground g2 = GameManager.Instance.GetGround(tposX, tposY);
                    d = player.myRight();
                    player.dirToPos(d,out tposX,out tposY);
                    Ground g3 = GameManager.Instance.GetGround(tposX, tposY);
                    if (g1.entities.Count == 0 || g2.entities.Count == 0 || g3.entities.Count == 0)
                    {
                        //不引爆
                        player.readyForExplode = false;
                        
                    }//尝试推动3个方向
                    else if (!player.Move(player.selfDir))
                    {
                        if (!player.Move(player.myLeft()))
                        {
                            if (!player.Move(player.myRight()))
                            {
                                //都无法推动则引爆
                                Explode(g1, g2, g3);
                            }
                        }
                    }
                }
                else
                {
                    //根据输入尝试移动
                    tryMove();
                }
                
            }
        }
        

        
    }

    void push(Entity.Dir dir)
    {

        if (dir == Entity.Dir.Up)
        {
            
        }
        
    }

    void Explode(Ground g1, Ground g2, Ground g3)
    {
        Ground g4, g5;
        //上下时，g1取Y, g2g3取X
        if (player.selfDir == Entity.Dir.Up || player.selfDir == Entity.Dir.Down)
        {
            g4 = GameManager.Instance.GetGround(g2.posX, g1.posY);
            g5 = GameManager.Instance.GetGround(g3.posX, g1.posY);
        }
        else
        {
            g4 = GameManager.Instance.GetGround(g1.posX, g2.posY);
            g5 = GameManager.Instance.GetGround(g1.posX, g3.posY);
        }
        ExplodeSingleGround(g1);
        ExplodeSingleGround(g2);
        ExplodeSingleGround(g3);
        ExplodeSingleGround(g4);
        ExplodeSingleGround(g5);
        
    }

    void ExplodeSingleGround(Ground g)
    {
        for (int i = 0; i < g.entities.Count; i++)
        {
            g.entities[i].SetActive(false);
            //Destroy(g.entities[i]);
        }
        g.entities.Clear();
    }
    
    void tryMove()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Right);
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Left);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Down);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isMove = true;
            player.Move(Entity.Dir.Up);
        }
    }

}

